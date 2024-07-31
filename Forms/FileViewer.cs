using FileViewer.Forms;
using FileViewer.Model;
using FileViewer.Utility;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Windows.Forms;

namespace FileViewer
{
    public partial class FileViewer : Form
    {
        private MainMenu mainMenu;
        private OpenFileDialog openFileDialog;
        private Dictionary<int, List<ElementContent>> _ds = null;
        private Dictionary<string, List<List<ElementContent>>> _lstTabContent = new Dictionary<string, List<List<ElementContent>>>();
        private int count = 1;
        //when using backgroundworker, if we want to access controls from UI, we must use delegate to get them
        delegate TabPage GetTabCallback();
        public FileViewer()
        {
            InitializeComponent();
            this.ctrlTabFileViewer.SizeMode = TabSizeMode.Normal;
            openFileDialog = new OpenFileDialog()
            {
                FileName = "Select a Alligacom file",
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*", 
                Title = "Open Alligacom file"
            };
            _initMenu();
            this.processBarExport.Visible = false;
            InitializeBackgroundWorker();
            this.FormClosed += FileViewer_FormClosed;
        }

        private void FileViewer_Load(object sender, EventArgs e)
        {
            List<TabConfig> lstTabConfig = SchemaModel.LoadTabOpen();
            TabPage tabSelected = null;
            foreach (var tabCfg in lstTabConfig)
            {

                TabPage tab = new TabPage(tabCfg.TabName);
                var currGrid = _initGrid((count++).ToString());
                string str = "";
                if (tabCfg.FilePath != "")
                {
                    str = File.ReadAllText(tabCfg.FilePath);
                    tab.ToolTipText = tabCfg.FilePath;
                }
                else if (tabCfg.FileTempPath != "")
                {
                    str = File.ReadAllText(tabCfg.FileTempPath);
                }
                if (!string.IsNullOrEmpty(str))
                {
                    try
                    {
                        _ds = new Dictionary<int, List<ElementContent>>();
                        _parseContent(str, currGrid);
                        DisableDataGridViewSorting(currGrid);
                        tab.Controls.Add(currGrid);
                    }
                    catch (Exception ex)
                    {
                        log.info(ex);
                        currGrid.Visible = false;
                        TextBox tbox = _initTextBox(Guid.NewGuid().ToString());
                        tbox.Text = str;
                        tab.Controls.Add(tbox);
                    }
                }
                else
                {
                    currGrid.Visible = false;
                    TextBox tbox = _initTextBox(Guid.NewGuid().ToString());
                    tbox.Text = str;
                    tab.Controls.Add(tbox);
                }
                if (tabCfg.IsActive)
                {
                    tabSelected = tab;
                }
                this.ctrlTabFileViewer.TabPages.Add(tab);
            }
            if (tabSelected!=null)
                this.ctrlTabFileViewer.SelectedTab = tabSelected;
        }

        private void FileViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            var tabPages = this.ctrlTabFileViewer.TabPages;
            List<TabConfig> lstTabConfig = new List<TabConfig>();
            foreach (TabPage tab in tabPages)
            {
                var fileName = tab.ToolTipText;
                if (File.Exists(fileName))
                {
                    lstTabConfig.Add(new TabConfig()
                    {
                        TabName = tab.Text,
                        FilePath = fileName,
                        FileTempPath = "",
                        IsActive = (tab == this.ctrlTabFileViewer.SelectedTab)
                    });
                }
                else
                {
                    var content = _getCtrlContent(tab);
                    File.WriteAllText(CONS.path + tab.Text, content);
                    lstTabConfig.Add(new TabConfig()
                    {
                        TabName = tab.Text,
                        FilePath = "",
                        FileTempPath = CONS.path + tab.Text,
                        IsActive = (tab == this.ctrlTabFileViewer.SelectedTab)
                    });
                }
            }
            SchemaModel.SaveTabOpen(lstTabConfig);
        }

        private string _getCtrlContent(TabPage tab)
        {
            var controls = tab.Controls;
            var content = "";
            foreach (Control control in controls)
            {
                if (control.GetType() == typeof(DataGridView))
                {
                    var grid = (DataGridView)control;
                    if (_lstTabContent.Count == 0 || !_lstTabContent.ContainsKey(grid.Name)) return content;
                    var ds = _lstTabContent[grid.Name];
                    var dta = grid.Rows;
                    if (dta.Count == 0) return content;

                    for (var i = 0; i < dta.Count; i++)
                    {
                        var dtaCells = dta[i].Cells;
                        if (dtaCells[0].Value == null) continue;
                        var schmCell = ds[i];
                        var lineContent = dtaCells[0].Value.ToString();
                        if (schmCell != null)
                        {
                            for (var j = 0; j < schmCell.Count; j++)
                            {
                                var cellVal = dtaCells[j + 1].Value.ToString();
                                if (lineContent.Length < schmCell[j].StartAt - 1)
                                {
                                    lineContent = lineContent.PadRight(schmCell[j].StartAt - 1);
                                }
                                lineContent += cellVal;
                            }
                        }
                        content += lineContent + "\r\n";
                    }
                    return content.TrimEnd(new char[] { '\r', '\n' });
                }
                else if (control.GetType() == typeof(TextBox))
                {
                    return ((TextBox)control).Text;
                }
            }
            return content;
        }

        private TabPage GetTabSelected()
        {
            if (this.ctrlTabFileViewer.InvokeRequired)
            {
                GetTabCallback d = new GetTabCallback(GetTabSelected);
                return (TabPage)this.Invoke(d);
            }
            else
            {
                return this.ctrlTabFileViewer.SelectedTab;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // Reset the text in the result label.
            lblExport.Text = String.Empty;
            processBarExport.Visible = true;
            btnExportNS.Enabled = false;

            // Start the asynchronous operation.
            var auth = GetAuthSettings(Erp.Netsuite);
            if (auth == null)
            {
                MessageBox.Show("Please setup ERP information to process."); return;
            }
            var paras = new ExportParams() { erp = Erp.Netsuite, auth = auth };
            backgroundWorker1.RunWorkerAsync(paras);
        }

        private void btnD3FO_Click(object sender, EventArgs e)
        {
            // Reset the text in the result label.
            lblExport.Text = String.Empty;
            processBarExport.Visible = true;
            btnExportNS.Enabled = false;

            // Start the asynchronous operation.
            var auth = GetAuthSettings(Erp.D3FO);
            if (auth == null)
            {
                MessageBox.Show("Please setup ERP information to process."); return;
            }
            var paras = new ExportParams() { erp = Erp.D3FO, auth = auth };
            backgroundWorker1.RunWorkerAsync(paras);
        }
        private void btnExp2BC_Click(object sender, EventArgs e)
        {
            // Reset the text in the result label.
            lblExport.Text = String.Empty;
            processBarExport.Visible = true;
            btnExportNS.Enabled = false;

            // Start the asynchronous operation.
            var auth = GetAuthSettings(Erp.BC);
            if (auth == null)
            {
                MessageBox.Show("Please setup ERP information to process."); return;
            }
            var paras = new ExportParams() { erp = Erp.BC, auth = auth };
            backgroundWorker1.RunWorkerAsync(paras);
        }

        private Auth GetAuthSettings(Erp erp)
        {
            var authSetting = SchemaModel.LoadDataSettings();
            var stSearch = authSetting.Where(x => x.erp == erp).FirstOrDefault();
            if (stSearch == null)
            {
                return null;
            }
            if (stSearch.authType == AuthType.Basic)
            {
                return new BasicAuth
                {
                    url = stSearch.url,
                    accountid = stSearch.account,
                    username = stSearch.basicAuth.username,
                    password = stSearch.basicAuth.password,
                    role = stSearch.basicAuth.role
                };
            }
            return new oAuth
            {
                url = stSearch.url,
                accountid = stSearch.oAuth.accountid,
                ConsumerKey = stSearch.oAuth.ConsumerKey,
                ConsumerSerect = stSearch.oAuth.ConsumerSerect,
                Token = stSearch.oAuth.Token,
                TokenSerect = stSearch.oAuth.TokenSerect,
                ClientId = stSearch.oAuth.ClientId,
                Tenant = stSearch.oAuth.Tenant
            };
        }

        private void InitializeBackgroundWorker()
        {
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(30);
            var paras = (ExportParams)e.Argument;
            e.Result = Export(GetTabSelected(), paras.auth, paras.erp);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            processBarExport.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(e.Result.ToString());
            processBarExport.Visible = false;
            btnExportNS.Enabled = true;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {

            btnExportNS.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        #region Menu Actions
        private void _initMenu()
        {
            mainMenu = new MainMenu();
            MenuItem File = mainMenu.MenuItems.Add("&File");
            File.MenuItems.Add(new MenuItem("&New", new EventHandler(this.FileNew_clicked), Shortcut.CtrlN));
            File.MenuItems.Add(new MenuItem("&Open", new EventHandler(this.FileOpen_clicked), Shortcut.CtrlO));
            File.MenuItems.Add(new MenuItem("&Save", new EventHandler(this.FileSave_clicked), Shortcut.CtrlS));
            File.MenuItems.Add(new MenuItem("&Save As", new EventHandler(this.FileSaveAs_clicked)));
            //   
            MenuItem Settings = mainMenu.MenuItems.Add("&Setting");
            Settings.MenuItems.Add(new MenuItem("&ERP Setup", new EventHandler(this.ERPSetup_clicked), Shortcut.Ctrl0));
            this.Menu = mainMenu;
            //
            File.MenuItems.Add(new MenuItem("-"));
            File.MenuItems.Add(new MenuItem("&View Schema", new EventHandler(this.btnSchema_Click)));
            File.MenuItems.Add(new MenuItem("&Import", new EventHandler(this.btnImportSchema_Click)));
            File.MenuItems.Add(new MenuItem("&Restore", new EventHandler(this.btnRestoreSchema_Click)));
            File.MenuItems.Add(new MenuItem("-"));
            File.MenuItems.Add(new MenuItem("&Exit", new EventHandler(this.FileExit_clicked), Shortcut.CtrlX));
            this.Menu = mainMenu;
            MenuItem About = mainMenu.MenuItems.Add("&About");
            About.MenuItems.Add(new MenuItem("&About", new EventHandler(this.About_clicked), Shortcut.F1));
            this.Menu = mainMenu;
            mainMenu.GetForm().BackColor = Color.WhiteSmoke;
        }
        private void FileExit_clicked(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ERPSetup_clicked(object sender, EventArgs e)
        {
            Settings st = new Settings();
            st.ShowDialog();
        }
        private void FileNew_clicked(object sender, EventArgs e)
        {
            AddNewTab("New File" + count++);
        }
        private void FileOpen_clicked(object sender, EventArgs e)
        {
            OpenFile();
        }
        private void FileSave_clicked(object sender, EventArgs e)
        {
            _saveFile(false);
        }
        private void FileSaveAs_clicked(object sender, EventArgs e)
        {
            _saveFile(true);
        }

        private void cmdPaste_Clicked(object sender, EventArgs e)
        {
            try
            {
                MenuItem menuItem = sender as MenuItem;
                if (menuItem != null)
                {
                    ContextMenu menu = menuItem.GetContextMenu();
                    Control sourceControl = menu.SourceControl;
                    CopyPasteCommand(sourceControl);
                }
            }
            catch (Exception ex)
            {
                log.info(ex);
                MessageBox.Show(ex.Message, "Error");
            }

        }
        private void cmdInsertRow_Clicked(object sender, EventArgs e)
        {
            try
            {
                MenuItem menuItem = sender as MenuItem;
                if (menuItem != null)
                {
                    ContextMenu menu = menuItem.GetContextMenu();
                    Control sourceControl = menu.SourceControl;
                    DataGridView grid = (DataGridView)sourceControl;
                    var rowSelected = grid.CurrentCell.RowIndex;
                    var colCopy = FindMaxColumn(grid);
                    grid.Rows.InsertCopy(colCopy, rowSelected + 1);
                    var ds = _lstTabContent[grid.Name];
                    ds.Insert(rowSelected + 1, null);
                    //just enter segment name
                    var cols = grid.ColumnCount;
                    for (var t = 1; t < cols; t++)
                    {
                        grid.Rows[rowSelected + 1].Cells[t].ReadOnly = true;
                        grid.Rows[rowSelected + 1].Cells[t].Style.BackColor = Color.LightGray;
                    }
                }
            }
            catch (Exception ex)
            {
                log.info(ex);
            }
        }
        private void grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ReloadGridData((DataGridView)sender);
            }
            catch (Exception ex)
            {
                log.info(ex);
                MessageBox.Show(ex.Message);
            }
        }
        private void ReloadGridData(DataGridView grid)
        {
            var ds = _lstTabContent[grid.Name];
            var dta = grid.Rows;
            string content = "";
            for (var i = 0; i < dta.Count; i++)
            {
                var dtaCells = dta[i].Cells;
                if (dtaCells[0].Value == null) continue;
                var schmCell = ds[i];
                var lineContent = dtaCells[0].Value.ToString();
                if (schmCell != null)
                {
                    for (var j = 0; j < schmCell.Count; j++)
                    {
                        var cellVal = dtaCells[j + 1].Value.ToString();
                        if (lineContent.Length < schmCell[j].StartAt - 1)
                        {
                            lineContent = lineContent.PadRight(schmCell[j].StartAt - 1);
                        }
                        lineContent += cellVal;
                    }
                }
                content += lineContent + "\r\n";
            }
            content = content.TrimEnd(new char[] { '\r', '\n' });
            var (parseContent, eleNum) = new Parser().ParseContent(content);
            //bind datasource to grid   
            ds = new List<List<ElementContent>>();
            for (var idx = 0; idx < parseContent.Count; idx++)
            {
                var x = parseContent[idx];
                var eles = x.Elements;
                grid.Rows[idx].Cells[0] = new DataGridViewTextBoxCell() { Value = x.SegmentName };
                Dictionary<int, string> toolTipValue = new Dictionary<int, string>();
                for (int i = 0; i < eles.Count; i++)
                {
                    var el = eles[i];
                    grid.Rows[idx].Cells[i + 1].ReadOnly = false;
                    grid.Rows[idx].Cells[i + 1] = new DataGridViewTextBoxCell() { Value = eles[i].ElementValue, MaxInputLength = el.Length };
                    string stra = string.Empty;
                    stra += "- DocType: " + el.DocType + "\r\n";
                    stra += "- Group    : " + el.GroupName + "\r\n";
                    stra += "- Segment: " + el.SegmentName + "\r\n";
                    stra += "- Element : " + el.ElementName + "\r\n";
                    stra += "- Start At : " + el.StartAt + "\r\n";
                    stra += "- Max Length : " + el.Length + "\r\n";
                    stra += "- Value      : " + el.ElementValue + "\r\n";
                    toolTipValue.Add(i + 1, stra);
                }
                for (var t = 1; t <= toolTipValue.Count; t++)
                {
                    grid.Rows[idx].Cells[t].ToolTipText = toolTipValue[t];
                }
                //disable cell have no elements
                //segment
                grid.Rows[0].Cells[0].ReadOnly = true;
                for (var t = toolTipValue.Count + 1; t <= eleNum; t++)
                {
                    grid.Rows[idx].Cells[t].ReadOnly = true;
                    grid.Rows[idx].Cells[t].Style.BackColor = Color.LightGray;
                }
                ds.Add(eles);
            };
            _lstTabContent[grid.Name] = ds;
        }

        private void cmdRemoveRow_Clicked(object sender, EventArgs e)
        {
            try
            {
                MenuItem menuItem = sender as MenuItem;
                if (menuItem != null)
                {
                    ContextMenu menu = menuItem.GetContextMenu();
                    Control sourceControl = menu.SourceControl;
                    DataGridView grid = (DataGridView)sourceControl;
                    var rowssSelected = grid.SelectedRows;
                    foreach (DataGridViewRow row in rowssSelected)
                    {
                        grid.Rows.RemoveAt(row.Index);
                        var ds = _lstTabContent[grid.Name];
                        ds.RemoveAt(grid.CurrentCell.RowIndex);
                        _lstTabContent[grid.Name] = ds;
                    }
                }
            }
            catch (Exception ex)
            {
                log.info(ex);
            }
        }
        private int FindMaxColumn(DataGridView grid)
        {
            var max = 1;
            var cols = grid.Columns.Count;
            for (var i = 0; i < grid.Rows.Count; i++)
            {
                var row = grid.Rows[i];
                if (!row.Cells[cols - 1].ReadOnly) return i;
            }
            return max;
        }
        private void About_clicked(object sender, EventArgs e)
        {
            About frm = new About();
            frm.ShowDialog();
        }
        #endregion Menu Actions

        #region Tooltrip Actions
        private void btnNew_Click(object sender, EventArgs e)
        {
            AddNewTab("New File " + count++);
        }
        private void OpenFile()
        {
            try
            {
                DialogResult dialogResult = openFileDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    TextBox tbox = null;
                    DataGridView grid = null;
                    TabPage tag = null;
                    string strContent = string.Empty;
                    try
                    {
                        var fileName = openFileDialog.FileName;
                        grid = _initGrid((count++).ToString());
                        tag = new TabPage(fileName.Substring(fileName.LastIndexOf('\\') + 1));
                        tag.ToolTipText = fileName;
                        tag.Controls.Add(grid);
                        this.ctrlTabFileViewer.TabPages.Add(tag);
                        this.ctrlTabFileViewer.SelectedTab = tag;
                        using (Stream str = openFileDialog.OpenFile())
                        {
                            var reader = new StreamReader(str);
                            strContent = reader.ReadToEnd();
                            _parseContent(strContent, grid);
                        }
                        DisableDataGridViewSorting(grid);
                    }
                    catch (SecurityException ex)
                    {
                        log.info(ex);
                        MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                        $"Details:\n\n{ex.StackTrace}");
                    }
                    catch (Exception exp)
                    {
                        log.info(exp);
                        MessageBox.Show(exp.Message);
                        tbox = _initTextBox((count++).ToString());
                        tbox.Text = strContent;
                        tag.Controls.Add(tbox);
                        grid.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                log.info(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _saveFile(false);
        }
        private void _saveFile(bool isSaveAs)
        {
            try
            {
                var tabCtrl = this.ctrlTabFileViewer.SelectedTab;
                if (tabCtrl == null) return;
                var controls = tabCtrl.Controls;
                foreach (Control control in controls)
                {
                    if (control.GetType() == typeof(DataGridView) && control.Visible)
                    {
                        var grid = (DataGridView)control;
                        var ds = _lstTabContent[grid.Name];
                        var dta = grid.Rows;
                        string content = "";
                        for (var i = 0; i < dta.Count; i++)
                        {
                            var dtaCells = dta[i].Cells;
                            if (dtaCells[0].Value == null) continue;
                            var schmCell = ds[i];
                            var lineContent = dtaCells[0].Value.ToString();
                            if (schmCell != null)
                            {
                                for (var j = 0; j < schmCell.Count; j++)
                                {
                                    var cellVal = dtaCells[j + 1].Value.ToString();
                                    if (lineContent.Length < schmCell[j].StartAt - 1)
                                    {
                                        lineContent = lineContent.PadRight(schmCell[j].StartAt - 1);
                                    }
                                    lineContent += cellVal;
                                }
                            }
                            content += lineContent + "\r\n";
                        }
                        content = content.TrimEnd(new char[] { '\r', '\n' });
                        string fileName = tabCtrl.ToolTipText;
                        if (File.Exists(fileName) && !isSaveAs)
                        {
                            File.WriteAllText(fileName, content);
                        }
                        else
                        {
                            SaveNewFile(content, tabCtrl);
                        }
                        //reload file
                        ReloadGridData(grid);
                        break;
                    }
                    else if (control.GetType() == typeof(TextBox) && control.Visible)
                    {
                        string fileName = tabCtrl.ToolTipText;
                        string content = ((TextBox)control).Text;
                        if (File.Exists(fileName) && !isSaveAs)
                        {
                            File.WriteAllText(fileName, content);
                        }
                        else
                        {
                            SaveNewFile(content, tabCtrl);
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                log.info(ex);
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void SaveNewFile(string content, TabPage tabCtrl)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            dlg.Title = "Browse Text Files";
            dlg.ShowDialog();
            if (dlg.FileName != string.Empty)
            {
                File.WriteAllText(dlg.FileName, content);
                tabCtrl.ToolTipText = dlg.FileName;
                tabCtrl.Text = dlg.FileName;
            }
        }

        private void btnSchema_Click(object sender, EventArgs e)
        {
            SchemaForm form = new SchemaForm();
            form.Show(this);
        }

        private void btnImportSchema_Click(object sender, EventArgs e)
        {
            ImportSchemas addForm = new ImportSchemas();
            addForm.StartPosition = FormStartPosition.CenterParent;
            addForm.ShowDialog(this);
        }

        private void btnRestoreSchema_Click(object sender, EventArgs e)
        {
            //copy files from lib to data
            try
            {
                if (MessageBox.Show("Your changes will be lost\r\nAre you sure to restore library?", "Confirm Restore!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string sourcePath = "Lib";
                    string targetPath = CONS.dataFolder;
                    string fileName = string.Empty;
                    Directory.CreateDirectory(targetPath);
                    if (Directory.Exists(sourcePath))
                    {
                        string[] files = Directory.GetFiles(sourcePath);
                        // Copy files and overwrite destination files if they already existed.
                        foreach (string s in files)
                        {
                            fileName = Path.GetFileName(s);
                            var destFile = Path.Combine(targetPath, fileName);
                            File.Copy(s, destFile, true);
                        }
                        MessageBox.Show("Restore completed.", "Restore");
                    }
                    else
                    {
                        MessageBox.Show($"Folder {targetPath} does not exist.", "Error!");
                    }
                }
            }
            catch (Exception ex)
            {
                log.info(ex);
                MessageBox.Show(ex.Message, "Error!");
            }
        }
        #endregion Tooltrip Actions

        #region Tab Action
        private void _parseContent(string strContent, DataGridView grid)
        {
            List<List<ElementContent>> ds = new List<List<ElementContent>>();
            var (parseContent, eleNum) = new Parser().ParseContent(strContent);
            //bind datasource to grid
            grid.Columns.Add("Segment", "Segment Name");
            for (int i = 0; i < eleNum; i++)
            {
                grid.Columns.Add("Element" + i, "Element " + (i + 1));
            }
            parseContent.ForEach(x =>
            {
                var eles = x.Elements;
                var idx = grid.Rows.Add();
                grid.Rows[idx].Cells[0] = new DataGridViewTextBoxCell() { Value = x.SegmentName };
                Dictionary<int, string> toolTipValue = new Dictionary<int, string>();
                for (int i = 0; i < eles.Count; i++)
                {
                    var el = eles[i];
                    grid.Rows[idx].Cells[i + 1] = new DataGridViewTextBoxCell()
                    {
                        Value = eles[i].ElementValue,
                        MaxInputLength = el.Length
                    };
                    string stra = string.Empty;
                    stra += "- DocType: " + el.DocType + "\r\n";
                    stra += "- Group    : " + el.GroupName + "\r\n";
                    stra += "- Segment: " + el.SegmentName + "\r\n";
                    stra += "- Element : " + el.ElementName + "\r\n";
                    stra += "- Start At : " + el.StartAt + "\r\n";
                    stra += "- Max Length : " + el.Length + "\r\n";
                    stra += "- Value      : " + el.ElementValue + "\r\n";
                    toolTipValue.Add(i + 1, stra);
                }
                for (var t = 1; t <= toolTipValue.Count; t++)
                {
                    grid.Rows[idx].Cells[t].ToolTipText = toolTipValue[t];
                }
                //disable cell have no element
                //segment
                grid.Rows[0].Cells[0].ReadOnly = true;
                for (var t = toolTipValue.Count + 1; t <= eleNum; t++)
                {
                    grid.Rows[idx].Cells[t].ReadOnly = true;
                    grid.Rows[idx].Cells[t].Style.BackColor = Color.LightGray;
                }
                ds.Add(eles);
            });
            _lstTabContent[grid.Name] = ds;
        }
        public void AddNewTab(string tabName)
        {
            TabPage tab = new TabPage(tabName);
            tab.Controls.Add(_initGrid((count++).ToString()));
            this.ctrlTabFileViewer.TabPages.Add(tab);
        }
        private DataGridView _initGrid(string name)
        {
            var grid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)(grid)).BeginInit();
            grid.GridColor = Color.DarkGray;
            grid.Columns.Clear();
            grid.RowHeadersDefaultCellStyle.BackColor = Color.DarkGray;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.Dock = System.Windows.Forms.DockStyle.Fill;
            grid.Location = new System.Drawing.Point(0, 0);
            grid.Name = name;
            grid.AllowDrop = true;
            grid.Size = new System.Drawing.Size(874, 505);
            grid.TabIndex = 0;
            if (!SystemInformation.TerminalServerSession)
            {
                Type dgvType = grid.GetType();
                PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(grid, true, null);
            }
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            grid.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            grid.MouseClick += Grid_MouseClick;
            grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            grid.KeyDown += new KeyEventHandler(Grid_KeyPress);
            grid.DragEnter += new DragEventHandler(Grid_DragEnter);
            grid.DragDrop += Grid_DragDrop;
            grid.CellValueChanged += grid_CellValueChanged;
            ((System.ComponentModel.ISupportInitialize)(grid)).EndInit();
            return grid;
        }

        private TextBox _initTextBox(string name)
        {
            var txtContent = new TextBox();
            txtContent.ForeColor = System.Drawing.SystemColors.ControlText;
            txtContent.Location = new System.Drawing.Point(206, 51);
            txtContent.Name = name;
            txtContent.Anchor = AnchorStyles.Top;
            txtContent.Dock = DockStyle.Fill;
            txtContent.TabIndex = 22;
            txtContent.Multiline = true;
            txtContent.ScrollBars = ScrollBars.Both;
            return txtContent;
        }
        private LineNumberTextBox _initTextBoxCustom(string name)
        {
            var txtContent = new LineNumberTextBox
            {
                ForeColor = System.Drawing.SystemColors.ControlText,
                Location = new System.Drawing.Point(206, 51),
                Name = name,
                Anchor = AnchorStyles.Top,
                Dock = DockStyle.Fill,
                TabIndex = 22
            };                        
            return txtContent;
        }

        private void Grid_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView grid = (DataGridView)sender;
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add("Paste", new EventHandler(cmdPaste_Clicked));
                string str = Clipboard.GetText();
                if (str == string.Empty)
                {
                    //set menu is disabled
                    var menuItems = m.MenuItems;
                    foreach (MenuItem mItem in menuItems)
                    {
                        if (mItem.Text == "Paste") mItem.Enabled = false;
                    }
                }
                int currentMouseOverRow = grid.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRow >= 0)
                {
                    m.MenuItems.Add("Insert New Segment", new EventHandler(cmdInsertRow_Clicked));
                    m.MenuItems.Add("Remove Segment", new EventHandler(cmdRemoveRow_Clicked));
                }
                m.Show(grid, new Point(e.X, e.Y));
            }
        }

        public void DisableDataGridViewSorting(DataGridView grid)
        {
            foreach (DataGridViewColumn column in grid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        #endregion Tab Action

        #region Grid Actions
        private void Grid_KeyPress(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.V)
                {
                    CopyPasteCommand(sender);
                }
            }
            catch (Exception ex)
            {
                log.info(ex);
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void Grid_DragDrop(object sender, DragEventArgs e)
        {
            var dta = e.Data.GetFormats();
            foreach (var d in dta)
            {
                if (d.Equals("FileNameW"))
                {
                    TabPage tab = null;
                    DataGridView grid = null;
                    string strContent = string.Empty;
                    try
                    {
                        var fileName = ((string[])e.Data.GetData(d))[0];
                        _ds = new Dictionary<int, List<ElementContent>>();

                        grid = _initGrid((count++).ToString());
                        tab = new TabPage(fileName.Substring(fileName.LastIndexOf('\\') + 1));
                        tab.Padding = new System.Windows.Forms.Padding(0);
                        tab.ToolTipText = fileName;
                        tab.Controls.Add(grid);
                        ctrlTabFileViewer.TabPages.Add(tab);
                        ctrlTabFileViewer.SelectedTab = ctrlTabFileViewer.TabPages[ctrlTabFileViewer.TabCount - 1];
                        using (StreamReader str = new StreamReader(fileName))
                        {
                            var reader = new StreamReader(str.BaseStream);
                            strContent = reader.ReadToEnd();

                            _parseContent(strContent, grid);
                        }
                        DisableDataGridViewSorting(grid);
                        break;
                    }
                    catch (Exception ex)
                    {
                        log.info(ex);
                        MessageBox.Show(ex.Message);
                        grid.Visible = false;
                        TextBox tbox = _initTextBox(Guid.NewGuid().ToString());
                        tbox.Text = strContent;
                        tab.Controls.Add(tbox);
                    }
                }
            }
        }

        private void Grid_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void CopyPasteCommand(object sender)
        {
            var currGrid = (DataGridView)sender;
            TabPage tab = (TabPage)currGrid.Parent;
            string str = string.Empty;
            try
            {
                currGrid.Columns.Clear();
                currGrid.Rows.Clear();
                _ds = new Dictionary<int, List<ElementContent>>();
                str = Clipboard.GetText();
                if (str == string.Empty) return;
                _parseContent(str, currGrid);
                DisableDataGridViewSorting(currGrid);
            }
            catch (Exception ex)
            {
                log.info(ex);
                MessageBox.Show(ex.Message);
                currGrid.Visible = false;
                TextBox tbox = _initTextBox(Guid.NewGuid().ToString());
                tbox.Text = str;
                tab.Controls.Add(tbox);
            }
        }
        #endregion

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                TabPage currentTab = ctrlTabFileViewer.SelectedTab;
                if (currentTab == null) return;
                var ctrls = currentTab.Controls;
                foreach (var ctrl in ctrls)
                {
                    if (ctrl.GetType() == typeof(DataGridView))
                    {
                        DataGridView grid = (DataGridView)ctrl;
                        var rowSelected = grid.CurrentCell.RowIndex;
                        var colCopy = FindMaxColumn(grid);
                        grid.Rows.InsertCopy(colCopy, rowSelected + 1);
                        var ds = _lstTabContent[grid.Name];
                        ds.Insert(rowSelected + 1, null);
                        //just enter segment name
                        var cols = grid.ColumnCount;
                        for (var t = 1; t < cols; t++)
                        {
                            grid.Rows[rowSelected + 1].Cells[t].ReadOnly = true;
                            grid.Rows[rowSelected + 1].Cells[t].Style.BackColor = Color.LightGray;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                log.info(ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            TabPage currentTab = ctrlTabFileViewer.SelectedTab;
            if (currentTab == null) return;
            var ctrls = currentTab.Controls;
            foreach (var ctrl in ctrls)
            {
                if (ctrl.GetType() == typeof(DataGridView))
                {
                    DataGridView grid = (DataGridView)ctrl;
                    var rowssSelected = grid.SelectedRows;
                    foreach (DataGridViewRow row in rowssSelected)
                    {
                        grid.Rows.RemoveAt(row.Index);
                        var ds = _lstTabContent[grid.Name];
                        ds.RemoveAt(grid.CurrentCell.RowIndex);
                        _lstTabContent[grid.Name] = ds;
                    }
                }
            }
        }
        private string Export(TabPage tp, Auth auth, Erp erp)
        {
            try
            {
                string content = GetContent2Export(tp);
                if (content == string.Empty)
                {
                    MessageBox.Show("Please select file to export");
                    return null;
                }
                var wsid = Guid.NewGuid();
                var body = $@"<?xml version=""1.0"" encoding=""UTF-8""?>
                                <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:eis=""urn:microsoft-dynamics-schemas/codeunit/EISUploadService"">
                                    <soapenv:Header/>
                                    <soapenv:Body>
                                        <eis:UploadDoc>
                                            <eis:sourceERP>{erp}</eis:sourceERP>
                                            <eis:diWS_ID>{wsid}</eis:diWS_ID>          
                                            <eis:documentContentText>{content}</eis:documentContentText>
                                        </eis:UploadDoc>
                                    </soapenv:Body>
                                </soapenv:Envelope>";
                if (typeof(BasicAuth) == auth.GetType())
                {
                    if (((BasicAuth)auth).role == 0)
                    {
                        return client.PostSoapService2((BasicAuth)auth, content);
                    }
                    else
                    {
                        return client.PostAuthor((BasicAuth)auth, body).ToString();
                    }
                }
                else
                {
                    if (erp == Erp.Netsuite)
                    {
                        return client.Post((oAuth)auth, body).Content;
                    }
                    else if (erp == Erp.D3FO)
                    {
                        return client.PostSoapService((oAuth)auth, content).ToString();
                    }
                    else if (erp == Erp.BC)
                    {
                        return client.Post((oAuth)auth, body).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                log.info(ex);
                MessageBox.Show(ex.Message, "Error");
            }
            return null;
        }

        private string GetContent2Export(TabPage tabCtrl)
        {
            string content = "";
            if (tabCtrl == null) return content;
            var controls = tabCtrl.Controls;
            foreach (Control control in controls)
            {
                if (control.GetType() == typeof(DataGridView) && control.Visible)
                {
                    var grid = (DataGridView)control;
                    if (_lstTabContent.Count == 0 || !_lstTabContent.ContainsKey(grid.Name)) return content;
                    var ds = _lstTabContent[grid.Name];
                    var dta = grid.Rows;
                    if (dta.Count == 0) return content;

                    for (var i = 0; i < dta.Count; i++)
                    {
                        var dtaCells = dta[i].Cells;
                        if (dtaCells[0].Value == null) continue;
                        var schmCell = ds[i];
                        var lineContent = dtaCells[0].Value.ToString();
                        if (schmCell != null)
                        {
                            for (var j = 0; j < schmCell.Count; j++)
                            {
                                var cellVal = dtaCells[j + 1].Value.ToString();
                                if (lineContent.Length < schmCell[j].StartAt - 1)
                                {
                                    lineContent = lineContent.PadRight(schmCell[j].StartAt - 1);
                                }
                                lineContent += cellVal;
                            }
                        }
                        content += lineContent + "\r\n";
                    }
                    content = content.TrimEnd(new char[] { '\r', '\n' });
                    return content;
                }
                else if (control.GetType() == typeof(TextBox) && control.Visible)
                {
                    var txt = (TextBox)control;
                    return txt.Text;
                }
            }
            return content;
        }

        //private void btnViewAsText_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var tabCtrl = this.ctrlTabFileViewer.SelectedTab;
        //        if (tabCtrl == null) return;
        //        var controls = tabCtrl.Controls;
        //        var content = GetContent2Export(tabCtrl);
        //        TextBox currTextBox = null;
        //        foreach (Control control in controls)
        //        {
        //            if (control.GetType() == typeof(DataGridView))
        //            {
        //                control.Visible = false;
        //                continue;
        //            }
        //            if (control.GetType() == typeof(TextBox))
        //            {
        //                currTextBox = (TextBox)control;
        //                currTextBox.Visible = true;
        //            }
        //        }
        //        if (currTextBox == null)
        //        {
        //            currTextBox = _initTextBox(Guid.NewGuid().ToString());
        //            tabCtrl.Controls.Add(currTextBox);
        //        }
        //        currTextBox.Text = content;
        //    }
        //    catch (Exception ex)
        //    {
        //        log.info(ex);
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void btnViewAsText_Click(object sender, EventArgs e)
        {
            try
            {
                var tabCtrl = this.ctrlTabFileViewer.SelectedTab;
                if (tabCtrl == null) return;
                var controls = tabCtrl.Controls;
                var content = GetContent2Export(tabCtrl);

                //TextBox currTextBox = null;
                LineNumberTextBox currTextBox = null;
                foreach (Control control in controls)
                {
                    var controlType = control.GetType();
                    if (controlType == typeof(DataGridView))
                    {
                        control.Visible = false;
                        continue;
                    }
                    else if (controlType == typeof(LineNumberTextBox))
                    {
                        currTextBox = (LineNumberTextBox)control;
                        currTextBox.Visible = true;
                        currTextBox.TextChangedEvent += LineNumberTextBox_TextChanged;
                        currTextBox.MouseDownEvent += LineNumberTextBox_MouseMove;
                    }
                }
                if (currTextBox == null)
                {                   
                    currTextBox = _initTextBoxCustom(Guid.NewGuid().ToString());
                    tabCtrl.Controls.Add(currTextBox);
                }
                currTextBox.Text = content;
            }
            catch (Exception ex)
            {
                log.info(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void btnViewAsGrid_Click(object sender, EventArgs e)
        {
            Control txt = null;
            DataGridView grv = null;
            try
            {
                var tabCtrl = this.ctrlTabFileViewer.SelectedTab;
                if (tabCtrl == null) return;
                var controls = tabCtrl.Controls;
                var content = string.Empty;
                DataGridView grid = null;
                foreach (Control control in controls)
                {
                    if (control.GetType() == typeof(LineNumberTextBox))
                    {
                        control.Visible = false;
                        txt = control;
                        var currTextBox = (LineNumberTextBox)control;
                        content = currTextBox.Text;
                        continue;
                    }
                    if (control.GetType() == typeof(DataGridView))
                    {
                        control.Visible = true;
                        grid = (DataGridView)control;
                    }
                }
                if (grid == null)
                {
                    grid = _initGrid(Guid.NewGuid().ToString());
                    tabCtrl.Controls.Add(grid);
                }
                grv = grid;
                grid.Columns.Clear();
                grid.Rows.Clear();
                string str = content;
                if (str == string.Empty) return;
                _parseContent(str, grid);
                DisableDataGridViewSorting(grid);
            }
            catch (Exception ex)
            {
                log.info(ex);
                MessageBox.Show(ex.Message);
                txt.Visible = true;
                grv.Visible = false;
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            LineNumberTextBoxForm frm = new LineNumberTextBoxForm();
            frm.ShowDialog();
        }

        private void LineNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateStatus((LineNumberTextBox)sender);
        }

        private void LineNumberTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            UpdateStatus((LineNumberTextBox)sender);
        }

        private void LineNumberTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            UpdateStatus((LineNumberTextBox)sender);
        }

        private void LineNumberTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateStatus((LineNumberTextBox)sender);
        }

        private void UpdateStatus(LineNumberTextBox lineNumberTextBox)
        {
            int index = lineNumberTextBox.SelectionStart;
            int line = lineNumberTextBox.GetLineFromCharIndex(index);
            int column = index - lineNumberTextBox.GetFirstCharIndexFromLine(line);
            //toolStripStatusLabel1.Text = $"Ln {line + 1}, Col {column + 1}";

            int wordCount = lineNumberTextBox.Text.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
            //toolStripStatusLabel2.Text = $"Word Count: {wordCount}";
        }
    }
}
