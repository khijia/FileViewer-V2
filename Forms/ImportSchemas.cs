using FileViewer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace FileViewer.Forms
{
    public partial class ImportSchemas : Form
    {
        private string[] source;
        private string[] target;
        private string _fileName;
        private string[] _sourceCols;
        public ImportSchemas()
        {
            InitializeComponent();
            LoadDataGrid();
            grvDocument.RowPrePaint += GrvSchema_RowPrePaint;
            if (!System.Windows.Forms.SystemInformation.TerminalServerSession)
            {
                Type dgvType = grvDocument.GetType();
                PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(grvDocument, true, null);
            }
            this.tabGroups.Enter += TabGroups_Enter;
            this.tabSegments.Enter += TabSegments_Enter;
            this.tabElements.Enter += TabElements_Enter;

            grvGroupMap.CellClick += DataGridView1_CellClick;
            grvSegMap.CellClick += DataGridView1_CellClick;
            grvEleMap.CellClick += DataGridView1_CellClick;
        }
        #region Events
        private void TabElements_Enter(object sender, EventArgs e)
        {
            LoadDocuments(this.cbEleDocument);
            this.cbEleDocument.SelectedIndex = this.cbDocument.Items.Count - 1;
        }

        private void TabSegments_Enter(object sender, EventArgs e)
        {
            LoadDocuments(this.cbSegDocument);
            this.cbSegDocument.SelectedIndex = this.cbDocument.Items.Count - 1;
        }

        private void TabGroups_Enter(object sender, EventArgs e)
        {
            LoadDocuments(this.cbDocument);
            this.cbDocument.SelectedIndex = this.cbDocument.Items.Count - 1;
        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex > -1)
                {
                    var grid = (DataGridView)sender;
                    DataGridViewComboBoxCell dropdown = new DataGridViewComboBoxCell();
                    if (grid.Columns[e.ColumnIndex].HeaderText.Contains("Source"))
                    {
                        grid[e.ColumnIndex, e.RowIndex] = dropdown;
                        dropdown.DataSource = source;
                    }

                    if (grid.Columns[e.ColumnIndex].HeaderText.Contains("Target"))
                    {
                        grid[e.ColumnIndex, e.RowIndex] = dropdown;
                        dropdown.DataSource = target;
                    }
                }
            }
            catch { }
        }
        #endregion Events

        #region Documents
        private void GrvSchema_RowPrePaint(object sender, System.Windows.Forms.DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                grvDocument.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Beige;
            }
        }
        private void LoadDocuments(ComboBox ctrl)
        {
            var lstDocs = SchemaModel.LoadDocumentFromLib();
            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = lstDocs;
            ctrl.DataSource = bindingSource1.DataSource;
            ctrl.DisplayMember = "DocType";
            ctrl.ValueMember = "Id";
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDocType.Text.Trim() == string.Empty || txtDocId.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter value for Document Type/ Document Id.", "Error");
                    return;
                }
                var lstDocs = SchemaModel.LoadDocumentFromLib();
                var search = lstDocs.Where(x => x.Id.ToString() == txtDocId.Text.Trim())
                    .FirstOrDefault();
                if (search != null)
                {
                    MessageBox.Show("Document has already exist.", "Error");
                    return;
                }
                var document = new List<Document>() {new Document()            {
                Id= int.Parse(txtDocId.Text),
                DocType=txtDocType.Text,
                Description= txtDesc.Text
            } };

                lstDocs.AddRange(document);
                SchemaModel.SaveDocument(lstDocs);
                LoadDataGrid();
                this.ctrlTabImport.SelectedTab = this.tabGroups;
            }
            catch (Exception ex)
            {
                log.info(ex);
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void btnImportSchema_Click(object sender, EventArgs e)
        {
            try
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();
                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        var flag = false;
                        string[] files = Directory.GetFiles(fbd.SelectedPath);
                        foreach (string s in files)
                        {
                            flag = true;
                            var destFile = Path.Combine(CONS.dataFolder, Path.GetFileName(s));
                            File.Copy(s, destFile, true);
                        }
                        if (flag)
                            MessageBox.Show("Import successful.", "Imported");
                    }
                }
            }
            catch (Exception ex)
            {
                log.info(ex);
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void btnExportSchema_Click(object sender, EventArgs e)
        {
            try
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();
                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {                       
                        string[] schemaFiles = { "Document.json" , "Group.json", "Segment.json", "Element.json" };
                        string[] files = Directory.GetFiles(CONS.dataFolder).Where(x=> schemaFiles.Contains(Path.GetFileName(x))).ToArray();
                        foreach (string s in files)
                        {
                            var destFile = Path.Combine(fbd.SelectedPath, Path.GetFileName(s));
                            File.Copy(s, destFile, true);
                        }
                        MessageBox.Show("Export successful.", "Exported");
                    }
                }
            }
            catch (Exception ex)
            {
                log.info(ex);
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void LoadDataGrid()
        {
            var data = SchemaModel.LoadDocumentFromLib();
            var dataGrid = new List<DataDocument>();
            data.ForEach(x =>
            {
                dataGrid.Add(new DataDocument()
                {
                    Id = x.Id,
                    DocType = x.DocType,
                    Description = x.Description
                });
            });
            grvDocument.DataSource = dataGrid;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this items ?", "Confirm Delete!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<int> docIds = new List<int>();
                foreach (DataGridViewRow row in grvDocument.SelectedRows)
                {
                    var docId = grvDocument.Rows[row.Index].Cells["Id"].Value;
                    docIds.Add(int.Parse(docId.ToString()));
                }
                _delete(docIds);
                LoadDataGrid();
            }
        }

        private void _delete(List<int> docIds)
        {
            var data = SchemaModel.LoadDocumentFromLib();
            data = data.Where(x => docIds.IndexOf(x.Id) == -1).ToList();
            SchemaModel.SaveDocument(data);
        }
        #endregion Documents       

        #region Groups
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            _fileName = BrowseFile();
            if (_fileName == string.Empty)
            {
                MessageBox.Show("Please select *csv file to import", "ERROR");
                return;
            }
            txtFile.Text = _fileName;
            _sourceCols = File.ReadAllLines(_fileName);
            source = _sourceCols.FirstOrDefault().Split(',');
            target = typeof(Group).GetProperties().Select(x => x.Name).ToArray();
        }

        private void btnImportGroup_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFile.Text == string.Empty)
                {
                    MessageBox.Show("Please select *csv file to import", "ERROR");
                    return;
                }
                var docId = ((Document)(cbDocument.SelectedItem)).Id;
                var lstGroups = SchemaModel.LoadGroupFromLib();
                var search = lstGroups.Where(x => x.DocumentId == docId)
                    .FirstOrDefault();
                if (search != null)
                {
                    if (MessageBox.Show("Groups already exist, do you want to re-import?", "Import!!", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    lstGroups = lstGroups.Where(x => x.DocumentId != docId).ToList();
                }
                var map = GetMap(grvGroupMap);
                var dta = _sourceCols
                            .Skip(1)
                            .Select(v =>
                            {
                                string[] values = v.Split(',');
                                var obj = new Group();
                                TurnArround(obj, values, map);
                                return obj;
                            })
                            .ToList();

                dta.AddRange(lstGroups);
                SchemaModel.SaveGroup(dta);
                txtFile.Text = string.Empty;
                MessageBox.Show("Import successfully.", "Successful");
                this.ctrlTabImport.SelectedTab = this.tabSegments;
            }
            catch (Exception ex)
            {
                log.info(ex);
                MessageBox.Show(ex.Message, "ERROR");
            }
        }
        #endregion
        #region Segments

        private void btnBrowseSeg_Click(object sender, EventArgs e)
        {
            _fileName = BrowseFile();
            if (_fileName == string.Empty)
            {
                MessageBox.Show("Please select *csv file to import", "ERROR");
                return;
            }
            txtFileSeg.Text = _fileName;
            _sourceCols = File.ReadAllLines(_fileName);
            source = _sourceCols.FirstOrDefault().Split(',');
            target = typeof(Segment).GetProperties().Select(x => x.Name).ToArray();
        }

        private void btnImportSeg_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFileSeg.Text == string.Empty)
                {
                    MessageBox.Show("Please select *csv file to import", "ERROR");
                    return;
                }
                var docId = ((Document)(cbSegDocument.SelectedItem)).Id;
                var lstSegments = SchemaModel.LoadSegmentFromLib();
                var search = lstSegments.Where(x => x.DocumentId == docId)
                    .FirstOrDefault();

                if (search != null)
                {
                    if (MessageBox.Show("Segments already exist, do you want to re-import?", "Import!!", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    lstSegments = lstSegments.Where(x => x.DocumentId != docId).ToList();
                }
                var map = GetMap(grvSegMap);
                var dta = _sourceCols
                            .Skip(1)
                            .Select(v =>
                            {
                                string[] values = v.Split(',');
                                var obj = new Segment();
                                TurnArround(obj, values, map);
                                return obj;
                            })
                            .ToList();

                dta.AddRange(lstSegments);
                SchemaModel.SaveSegment(dta);
                txtFileSeg.Text = string.Empty;
                MessageBox.Show("Import successfully.", "Success");
                this.ctrlTabImport.SelectedTab = this.tabElements;
            }
            catch (Exception ex)
            {
                log.info(ex);
                MessageBox.Show(ex.Message, "ERROR");
            }
        }
        #endregion
        #region Elements
        private void btnBrowseEle_Click(object sender, EventArgs e)
        {
            _fileName = BrowseFile();
            if (_fileName == string.Empty)
            {
                MessageBox.Show("Please select *csv file to import", "ERROR");
                return;
            }
            txtFileEle.Text = _fileName;
            _sourceCols = File.ReadAllLines(_fileName);
            source = _sourceCols.FirstOrDefault().Split(',');
            target = typeof(Element).GetProperties().Select(x => x.Name).ToArray();
        }

        private void btnImportEle_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFileEle.Text == string.Empty)
                {
                    MessageBox.Show("Please select *csv file to import", "ERROR");
                    return;
                }
                var docId = ((Document)(cbEleDocument.SelectedItem)).Id;
                var lstElements = SchemaModel.LoadElementFromLib();
                var search = lstElements.Where(x => x.Document == docId)
                    .FirstOrDefault();
                if (search != null)
                {
                    if (MessageBox.Show("Elements already exist, do you want to re-import?", "Import!!", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    lstElements = lstElements.Where(x => x.Document != docId).ToList();
                }
                var map = GetMap(grvEleMap);
                var dta = _sourceCols
                            .Skip(1)
                            .Select(v =>
                            {
                                string[] values = v.Split(',');
                                var obj = new Element();
                                TurnArround(obj, values, map);
                                return obj;
                            })
                            .ToList();

                dta.AddRange(lstElements);
                SchemaModel.SaveElement(dta);
                txtFileEle.Text = string.Empty;
                MessageBox.Show("Import successfully.", "Success");
            }
            catch (Exception ex)
            {
                log.info(ex);
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        #endregion

        private string BrowseFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                FileName = "Select a text file",
                Filter = "Text files (*.csv)|*.csv",
                Title = "Open text file"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }
            return string.Empty;
        }
        private Dictionary<string, int> GetMap(DataGridView grid)
        {
            List<List<string>> lst = new List<List<string>>();
            for (var i = 0; i < grid.Rows.Count; i++)
            {
                var src = grid.Rows[i].Cells[0].Value;//"Source"
                var tar = grid.Rows[i].Cells[1].Value;//"Target"
                if (src == null || tar == null) continue;
                lst.Add(new List<string> { src.ToString(), tar.ToString() });
            }
            var arrIdx = _sourceCols.FirstOrDefault().Split(',');
            Dictionary<string, int> header = new Dictionary<string, int>();
            for (var i = 0; i < arrIdx.Length; i++)
            {
                var colMap = lst.Where(x => x[0] == arrIdx[i]).FirstOrDefault();
                if (colMap == null) continue;
                header.Add(colMap[1], i);
            }
            return header;
        }
        private void TurnArround(Node obj, string[] values, Dictionary<string, int> header)
        {
            string val;
            var propGroup = obj.GetType().GetProperties();
            foreach (var prp in propGroup)
            {

                var prpInMap = header.Where(x => x.Key == prp.Name).FirstOrDefault();
                if (prpInMap.Key == null) continue;
                val = values[prpInMap.Value];
                if (prp.PropertyType == typeof(Int32))
                    prp.SetValue(obj, int.Parse(values[prpInMap.Value]));
                else if (prp.PropertyType == typeof(Char))
                    prp.SetValue(obj, char.Parse(values[prpInMap.Value]));
                else if (prp.PropertyType == typeof(string))
                    prp.SetValue(obj, values[prpInMap.Value]);

            }

        }
    }
}
