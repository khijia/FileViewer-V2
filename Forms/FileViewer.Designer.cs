
using FileViewer.Utility;

namespace FileViewer
{
    partial class FileViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;       

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileViewer));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSchema = new System.Windows.Forms.ToolStripButton();
            this.btnImportSchema = new System.Windows.Forms.ToolStripButton();
            this.btnRestoreSchema = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportNS = new System.Windows.Forms.ToolStripButton();
            this.btnD3FO = new System.Windows.Forms.ToolStripButton();
            this.btnExp2BC = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.lblExport = new System.Windows.Forms.ToolStripLabel();
            this.processBarExport = new System.Windows.Forms.ToolStripProgressBar();
            this.btnInsert = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnViewAsText = new System.Windows.Forms.ToolStripButton();
            this.btnViewAsGrid = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctrlTabFileViewer = new System.Windows.Forms.CustomTabControl();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();           
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnOpen,
            this.btnSave,
            this.toolStripSeparator2,
            this.btnSchema,
            this.btnImportSchema,
            this.btnRestoreSchema,
            this.toolStripSeparator1,
            this.btnExportNS,
            this.btnD3FO,
            this.btnExp2BC,
            this.toolStripSeparator4,
            this.lblExport,
            this.processBarExport,
            this.btnInsert,
            this.btnDelete,
            this.btnViewAsText,
            this.btnViewAsGrid,
            this.toolStripButton1});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // btnNew
            // 
            this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNew.Image = global::FileViewer.Properties.Resources._new;
            resources.ApplyResources(this.btnNew, "btnNew");
            this.btnNew.Name = "btnNew";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpen.Image = global::FileViewer.Properties.Resources.OpenSchemaList;
            resources.ApplyResources(this.btnOpen, "btnOpen");
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::FileViewer.Properties.Resources.save;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // btnSchema
            // 
            this.btnSchema.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSchema.Image = global::FileViewer.Properties.Resources.addressbook;
            resources.ApplyResources(this.btnSchema, "btnSchema");
            this.btnSchema.Name = "btnSchema";
            this.btnSchema.Click += new System.EventHandler(this.btnSchema_Click);
            // 
            // btnImportSchema
            // 
            this.btnImportSchema.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnImportSchema.Image = global::FileViewer.Properties.Resources.redo;
            resources.ApplyResources(this.btnImportSchema, "btnImportSchema");
            this.btnImportSchema.Name = "btnImportSchema";
            this.btnImportSchema.Click += new System.EventHandler(this.btnImportSchema_Click);
            // 
            // btnRestoreSchema
            // 
            this.btnRestoreSchema.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRestoreSchema.Image = global::FileViewer.Properties.Resources.undo;
            resources.ApplyResources(this.btnRestoreSchema, "btnRestoreSchema");
            this.btnRestoreSchema.Name = "btnRestoreSchema";
            this.btnRestoreSchema.Click += new System.EventHandler(this.btnRestoreSchema_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // btnExportNS
            // 
            this.btnExportNS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExportNS.Image = global::FileViewer.Properties.Resources.ns;
            resources.ApplyResources(this.btnExportNS, "btnExportNS");
            this.btnExportNS.Name = "btnExportNS";
            this.btnExportNS.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnD3FO
            // 
            this.btnD3FO.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnD3FO.Image = global::FileViewer.Properties.Resources.ax;
            resources.ApplyResources(this.btnD3FO, "btnD3FO");
            this.btnD3FO.Name = "btnD3FO";
            this.btnD3FO.Click += new System.EventHandler(this.btnD3FO_Click);
            // 
            // btnExp2BC
            // 
            this.btnExp2BC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExp2BC.Image = global::FileViewer.Properties.Resources.bc_icon;
            resources.ApplyResources(this.btnExp2BC, "btnExp2BC");
            this.btnExp2BC.Name = "btnExp2BC";
            this.btnExp2BC.Click += new System.EventHandler(this.btnExp2BC_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // lblExport
            // 
            this.lblExport.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblExport.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblExport.Name = "lblExport";
            resources.ApplyResources(this.lblExport, "lblExport");
            // 
            // processBarExport
            // 
            this.processBarExport.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.processBarExport.Name = "processBarExport";
            resources.ApplyResources(this.processBarExport, "processBarExport");
            // 
            // btnInsert
            // 
            this.btnInsert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnInsert.Image = global::FileViewer.Properties.Resources.Add1;
            resources.ApplyResources(this.btnInsert, "btnInsert");
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = global::FileViewer.Properties.Resources.delete;
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnViewAsText
            // 
            this.btnViewAsText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnViewAsText.Image = global::FileViewer.Properties.Resources.outputGrid;
            resources.ApplyResources(this.btnViewAsText, "btnViewAsText");
            this.btnViewAsText.Name = "btnViewAsText";
            this.btnViewAsText.Click += new System.EventHandler(this.btnViewAsText_Click);
            // 
            // btnViewAsGrid
            // 
            this.btnViewAsGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnViewAsGrid.Image = global::FileViewer.Properties.Resources.inputGrid;
            resources.ApplyResources(this.btnViewAsGrid, "btnViewAsGrid");
            this.btnViewAsGrid.Name = "btnViewAsGrid";
            this.btnViewAsGrid.Click += new System.EventHandler(this.btnViewAsGrid_Click);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.ctrlTabFileViewer);
            this.panel1.Name = "panel1";
            // 
            // ctrlTabFileViewer
            // 
            this.ctrlTabFileViewer.AllowDrop = true;
            this.ctrlTabFileViewer.DisplayStyle = System.Windows.Forms.TabStyle.IE8;
            // 
            // 
            // 
            this.ctrlTabFileViewer.DisplayStyleProvider.BorderColor = System.Drawing.Color.Gainsboro;
            this.ctrlTabFileViewer.DisplayStyleProvider.BorderColorHot = System.Drawing.SystemColors.ControlDark;
            this.ctrlTabFileViewer.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.DarkGray;
            this.ctrlTabFileViewer.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
            this.ctrlTabFileViewer.DisplayStyleProvider.CloserColorActive = System.Drawing.Color.Red;
            this.ctrlTabFileViewer.DisplayStyleProvider.FocusColor = System.Drawing.Color.DarkSeaGreen;
            this.ctrlTabFileViewer.DisplayStyleProvider.FocusTrack = false;
            this.ctrlTabFileViewer.DisplayStyleProvider.HotTrack = true;
            this.ctrlTabFileViewer.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ctrlTabFileViewer.DisplayStyleProvider.Opacity = 1F;
            this.ctrlTabFileViewer.DisplayStyleProvider.Overlap = 0;
            this.ctrlTabFileViewer.DisplayStyleProvider.Padding = new System.Drawing.Point(0, 0);
            this.ctrlTabFileViewer.DisplayStyleProvider.Radius = 3;
            this.ctrlTabFileViewer.DisplayStyleProvider.ShowTabCloser = true;
            this.ctrlTabFileViewer.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText;
            this.ctrlTabFileViewer.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            this.ctrlTabFileViewer.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.ctrlTabFileViewer, "ctrlTabFileViewer");
            this.ctrlTabFileViewer.HotTrack = true;
            this.ctrlTabFileViewer.Name = "ctrlTabFileViewer";
            this.ctrlTabFileViewer.SelectedIndex = 0;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // FileViewer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = global::FileViewer.Properties.Resources.file1;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "FileViewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FileViewer_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnSchema;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CustomTabControl ctrlTabFileViewer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnImportSchema;
        private System.Windows.Forms.ToolStripButton btnRestoreSchema;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnInsert;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnExportNS;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel lblExport;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripProgressBar processBarExport;
        private System.Windows.Forms.ToolStripButton btnD3FO;
        private System.Windows.Forms.ToolStripButton btnExp2BC;
        private System.Windows.Forms.ToolStripButton btnViewAsText;
        private System.Windows.Forms.ToolStripButton btnViewAsGrid;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}