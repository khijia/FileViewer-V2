
namespace FileViewer.Forms
{
    partial class ImportSchemas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportSchemas));
            this.panelForm = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.ctrlTabImport = new System.Windows.Forms.CustomTabControl();
            this.tabDocuments = new System.Windows.Forms.TabPage();
            this.btnDelete = new System.Windows.Forms.Button();
            this.grvDocument = new System.Windows.Forms.DataGridView();
            this.txtDocId = new System.Windows.Forms.TextBox();
            this.btnImportSchema = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtDocType = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabGroups = new System.Windows.Forms.TabPage();
            this.grvGroupMap = new System.Windows.Forms.DataGridView();
            this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Target = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnImportGroup = new System.Windows.Forms.Button();
            this.btnBrowseGroup = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.cbDocument = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabSegments = new System.Windows.Forms.TabPage();
            this.grvSegMap = new System.Windows.Forms.DataGridView();
            this.SegSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SegTarget = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnImportSeg = new System.Windows.Forms.Button();
            this.btnBrowseSeg = new System.Windows.Forms.Button();
            this.txtFileSeg = new System.Windows.Forms.TextBox();
            this.cbSegDocument = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabElements = new System.Windows.Forms.TabPage();
            this.grvEleMap = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnImportEle = new System.Windows.Forms.Button();
            this.btnBrowseEle = new System.Windows.Forms.Button();
            this.txtFileEle = new System.Windows.Forms.TextBox();
            this.cbEleDocument = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblImportSchema = new System.Windows.Forms.Label();
            this.btnExportSchema = new System.Windows.Forms.Button();
            this.panelForm.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.ctrlTabImport.SuspendLayout();
            this.tabDocuments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvDocument)).BeginInit();
            this.tabGroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvGroupMap)).BeginInit();
            this.tabSegments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvSegMap)).BeginInit();
            this.tabElements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvEleMap)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelForm
            // 
            this.panelForm.Controls.Add(this.pnlContent);
            this.panelForm.Controls.Add(this.pnlHeader);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForm.Location = new System.Drawing.Point(0, 0);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(830, 576);
            this.panelForm.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.ctrlTabImport);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlContent.Location = new System.Drawing.Point(0, 84);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(830, 491);
            this.pnlContent.TabIndex = 1;
            // 
            // ctrlTabImport
            // 
            this.ctrlTabImport.AllowDrop = true;
            this.ctrlTabImport.Controls.Add(this.tabDocuments);
            this.ctrlTabImport.Controls.Add(this.tabGroups);
            this.ctrlTabImport.Controls.Add(this.tabSegments);
            this.ctrlTabImport.Controls.Add(this.tabElements);
            this.ctrlTabImport.DisplayStyle = System.Windows.Forms.TabStyle.IE8;
            // 
            // 
            // 
            this.ctrlTabImport.DisplayStyleProvider.BorderColor = System.Drawing.Color.Gainsboro;
            this.ctrlTabImport.DisplayStyleProvider.BorderColorHot = System.Drawing.SystemColors.ControlDark;
            this.ctrlTabImport.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.DarkGray;
            this.ctrlTabImport.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
            this.ctrlTabImport.DisplayStyleProvider.CloserColorActive = System.Drawing.Color.Red;
            this.ctrlTabImport.DisplayStyleProvider.FocusColor = System.Drawing.Color.DarkSeaGreen;
            this.ctrlTabImport.DisplayStyleProvider.FocusTrack = false;
            this.ctrlTabImport.DisplayStyleProvider.HotTrack = true;
            this.ctrlTabImport.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ctrlTabImport.DisplayStyleProvider.Opacity = 1F;
            this.ctrlTabImport.DisplayStyleProvider.Overlap = 0;
            this.ctrlTabImport.DisplayStyleProvider.Padding = new System.Drawing.Point(0, 0);
            this.ctrlTabImport.DisplayStyleProvider.Radius = 3;
            this.ctrlTabImport.DisplayStyleProvider.ShowTabCloser = false;
            this.ctrlTabImport.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText;
            this.ctrlTabImport.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            this.ctrlTabImport.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            this.ctrlTabImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlTabImport.HotTrack = true;
            this.ctrlTabImport.ItemSize = new System.Drawing.Size(60, 16);
            this.ctrlTabImport.Location = new System.Drawing.Point(0, 0);
            this.ctrlTabImport.Name = "ctrlTabImport";
            this.ctrlTabImport.SelectedIndex = 0;
            this.ctrlTabImport.Size = new System.Drawing.Size(830, 491);
            this.ctrlTabImport.TabIndex = 10;
            // 
            // tabDocuments
            // 
            this.tabDocuments.Controls.Add(this.btnDelete);
            this.tabDocuments.Controls.Add(this.grvDocument);
            this.tabDocuments.Controls.Add(this.txtDocId);
            this.tabDocuments.Controls.Add(this.btnExportSchema);
            this.tabDocuments.Controls.Add(this.btnImportSchema);
            this.tabDocuments.Controls.Add(this.btnImport);
            this.tabDocuments.Controls.Add(this.txtDesc);
            this.tabDocuments.Controls.Add(this.txtDocType);
            this.tabDocuments.Controls.Add(this.label6);
            this.tabDocuments.Controls.Add(this.label2);
            this.tabDocuments.Controls.Add(this.label1);
            this.tabDocuments.Location = new System.Drawing.Point(4, 21);
            this.tabDocuments.Name = "tabDocuments";
            this.tabDocuments.Padding = new System.Windows.Forms.Padding(3);
            this.tabDocuments.Size = new System.Drawing.Size(822, 466);
            this.tabDocuments.TabIndex = 0;
            this.tabDocuments.Text = "Documents";
            this.tabDocuments.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnDelete.Location = new System.Drawing.Point(12, 429);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 28);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // grvDocument
            // 
            this.grvDocument.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvDocument.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.grvDocument.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvDocument.Location = new System.Drawing.Point(12, 59);
            this.grvDocument.Name = "grvDocument";
            this.grvDocument.Size = new System.Drawing.Size(804, 360);
            this.grvDocument.TabIndex = 16;
            // 
            // txtDocId
            // 
            this.txtDocId.Location = new System.Drawing.Point(12, 30);
            this.txtDocId.Name = "txtDocId";
            this.txtDocId.Size = new System.Drawing.Size(67, 20);
            this.txtDocId.TabIndex = 15;
            // 
            // btnImportSchema
            // 
            this.btnImportSchema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportSchema.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnImportSchema.Location = new System.Drawing.Point(103, 429);
            this.btnImportSchema.Name = "btnImportSchema";
            this.btnImportSchema.Size = new System.Drawing.Size(85, 28);
            this.btnImportSchema.TabIndex = 14;
            this.btnImportSchema.Text = "Import";
            this.btnImportSchema.UseVisualStyleBackColor = true;
            this.btnImportSchema.Click += new System.EventHandler(this.btnImportSchema_Click);
            // 
            // btnImport
            // 
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnImport.Location = new System.Drawing.Point(414, 27);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(72, 25);
            this.btnImport.TabIndex = 14;
            this.btnImport.Text = "Add";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(171, 30);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(235, 20);
            this.txtDesc.TabIndex = 12;
            // 
            // txtDocType
            // 
            this.txtDocType.Location = new System.Drawing.Point(85, 30);
            this.txtDocType.Name = "txtDocType";
            this.txtDocType.Size = new System.Drawing.Size(80, 20);
            this.txtDocType.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label6.Location = new System.Drawing.Point(168, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(83, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Document Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Document Id";
            // 
            // tabGroups
            // 
            this.tabGroups.Controls.Add(this.grvGroupMap);
            this.tabGroups.Controls.Add(this.btnImportGroup);
            this.tabGroups.Controls.Add(this.btnBrowseGroup);
            this.tabGroups.Controls.Add(this.txtFile);
            this.tabGroups.Controls.Add(this.cbDocument);
            this.tabGroups.Controls.Add(this.label3);
            this.tabGroups.Controls.Add(this.label4);
            this.tabGroups.Location = new System.Drawing.Point(4, 21);
            this.tabGroups.Name = "tabGroups";
            this.tabGroups.Padding = new System.Windows.Forms.Padding(3);
            this.tabGroups.Size = new System.Drawing.Size(822, 466);
            this.tabGroups.TabIndex = 1;
            this.tabGroups.Text = "Groups";
            this.tabGroups.UseVisualStyleBackColor = true;
            // 
            // grvGroupMap
            // 
            this.grvGroupMap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvGroupMap.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PapayaWhip;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvGroupMap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grvGroupMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvGroupMap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Source,
            this.Target});
            this.grvGroupMap.EnableHeadersVisualStyles = false;
            this.grvGroupMap.GridColor = System.Drawing.Color.WhiteSmoke;
            this.grvGroupMap.Location = new System.Drawing.Point(12, 59);
            this.grvGroupMap.Name = "grvGroupMap";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvGroupMap.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grvGroupMap.Size = new System.Drawing.Size(804, 360);
            this.grvGroupMap.TabIndex = 11;
            // 
            // Source
            // 
            this.Source.HeaderText = "Source";
            this.Source.Name = "Source";
            // 
            // Target
            // 
            this.Target.HeaderText = "Target";
            this.Target.Name = "Target";
            // 
            // btnImportGroup
            // 
            this.btnImportGroup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnImportGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportGroup.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnImportGroup.Location = new System.Drawing.Point(12, 429);
            this.btnImportGroup.Name = "btnImportGroup";
            this.btnImportGroup.Size = new System.Drawing.Size(85, 28);
            this.btnImportGroup.TabIndex = 10;
            this.btnImportGroup.Text = "Import";
            this.btnImportGroup.UseVisualStyleBackColor = true;
            this.btnImportGroup.Click += new System.EventHandler(this.btnImportGroup_Click);
            // 
            // btnBrowseGroup
            // 
            this.btnBrowseGroup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBrowseGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseGroup.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnBrowseGroup.Location = new System.Drawing.Point(435, 28);
            this.btnBrowseGroup.Name = "btnBrowseGroup";
            this.btnBrowseGroup.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseGroup.TabIndex = 9;
            this.btnBrowseGroup.Text = "Browse";
            this.btnBrowseGroup.UseVisualStyleBackColor = true;
            this.btnBrowseGroup.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFile
            // 
            this.txtFile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFile.Location = new System.Drawing.Point(138, 31);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(291, 20);
            this.txtFile.TabIndex = 8;
            // 
            // cbDocument
            // 
            this.cbDocument.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbDocument.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDocument.FormattingEnabled = true;
            this.cbDocument.Location = new System.Drawing.Point(12, 30);
            this.cbDocument.Name = "cbDocument";
            this.cbDocument.Size = new System.Drawing.Size(120, 21);
            this.cbDocument.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(135, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "From";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(9, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Document";
            // 
            // tabSegments
            // 
            this.tabSegments.Controls.Add(this.grvSegMap);
            this.tabSegments.Controls.Add(this.btnImportSeg);
            this.tabSegments.Controls.Add(this.btnBrowseSeg);
            this.tabSegments.Controls.Add(this.txtFileSeg);
            this.tabSegments.Controls.Add(this.cbSegDocument);
            this.tabSegments.Controls.Add(this.label5);
            this.tabSegments.Controls.Add(this.label7);
            this.tabSegments.Location = new System.Drawing.Point(4, 21);
            this.tabSegments.Name = "tabSegments";
            this.tabSegments.Padding = new System.Windows.Forms.Padding(3);
            this.tabSegments.Size = new System.Drawing.Size(822, 466);
            this.tabSegments.TabIndex = 2;
            this.tabSegments.Text = "Segments";
            this.tabSegments.UseVisualStyleBackColor = true;
            // 
            // grvSegMap
            // 
            this.grvSegMap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvSegMap.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.PapayaWhip;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvSegMap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grvSegMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvSegMap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SegSource,
            this.SegTarget});
            this.grvSegMap.EnableHeadersVisualStyles = false;
            this.grvSegMap.GridColor = System.Drawing.Color.WhiteSmoke;
            this.grvSegMap.Location = new System.Drawing.Point(12, 59);
            this.grvSegMap.Name = "grvSegMap";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvSegMap.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grvSegMap.Size = new System.Drawing.Size(804, 360);
            this.grvSegMap.TabIndex = 12;
            // 
            // SegSource
            // 
            this.SegSource.HeaderText = "Source";
            this.SegSource.Name = "SegSource";
            // 
            // SegTarget
            // 
            this.SegTarget.HeaderText = "Target";
            this.SegTarget.Name = "SegTarget";
            // 
            // btnImportSeg
            // 
            this.btnImportSeg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnImportSeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportSeg.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnImportSeg.Location = new System.Drawing.Point(12, 429);
            this.btnImportSeg.Name = "btnImportSeg";
            this.btnImportSeg.Size = new System.Drawing.Size(85, 28);
            this.btnImportSeg.TabIndex = 10;
            this.btnImportSeg.Text = "Import";
            this.btnImportSeg.UseVisualStyleBackColor = true;
            this.btnImportSeg.Click += new System.EventHandler(this.btnImportSeg_Click);
            // 
            // btnBrowseSeg
            // 
            this.btnBrowseSeg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBrowseSeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseSeg.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnBrowseSeg.Location = new System.Drawing.Point(435, 28);
            this.btnBrowseSeg.Name = "btnBrowseSeg";
            this.btnBrowseSeg.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseSeg.TabIndex = 9;
            this.btnBrowseSeg.Text = "Browse";
            this.btnBrowseSeg.UseVisualStyleBackColor = true;
            this.btnBrowseSeg.Click += new System.EventHandler(this.btnBrowseSeg_Click);
            // 
            // txtFileSeg
            // 
            this.txtFileSeg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFileSeg.Location = new System.Drawing.Point(138, 31);
            this.txtFileSeg.Name = "txtFileSeg";
            this.txtFileSeg.Size = new System.Drawing.Size(291, 20);
            this.txtFileSeg.TabIndex = 8;
            // 
            // cbSegDocument
            // 
            this.cbSegDocument.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbSegDocument.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSegDocument.FormattingEnabled = true;
            this.cbSegDocument.Location = new System.Drawing.Point(12, 30);
            this.cbSegDocument.Name = "cbSegDocument";
            this.cbSegDocument.Size = new System.Drawing.Size(120, 21);
            this.cbSegDocument.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(135, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "From";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label7.Location = new System.Drawing.Point(9, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Document";
            // 
            // tabElements
            // 
            this.tabElements.Controls.Add(this.grvEleMap);
            this.tabElements.Controls.Add(this.btnImportEle);
            this.tabElements.Controls.Add(this.btnBrowseEle);
            this.tabElements.Controls.Add(this.txtFileEle);
            this.tabElements.Controls.Add(this.cbEleDocument);
            this.tabElements.Controls.Add(this.label8);
            this.tabElements.Controls.Add(this.label9);
            this.tabElements.Location = new System.Drawing.Point(4, 21);
            this.tabElements.Name = "tabElements";
            this.tabElements.Padding = new System.Windows.Forms.Padding(3);
            this.tabElements.Size = new System.Drawing.Size(822, 466);
            this.tabElements.TabIndex = 3;
            this.tabElements.Text = "Elements";
            this.tabElements.UseVisualStyleBackColor = true;
            // 
            // grvEleMap
            // 
            this.grvEleMap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvEleMap.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.PapayaWhip;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvEleMap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grvEleMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvEleMap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.grvEleMap.EnableHeadersVisualStyles = false;
            this.grvEleMap.GridColor = System.Drawing.Color.WhiteSmoke;
            this.grvEleMap.Location = new System.Drawing.Point(12, 59);
            this.grvEleMap.Name = "grvEleMap";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvEleMap.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grvEleMap.Size = new System.Drawing.Size(804, 360);
            this.grvEleMap.TabIndex = 13;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Source";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Target";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // btnImportEle
            // 
            this.btnImportEle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnImportEle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportEle.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnImportEle.Location = new System.Drawing.Point(12, 429);
            this.btnImportEle.Name = "btnImportEle";
            this.btnImportEle.Size = new System.Drawing.Size(85, 28);
            this.btnImportEle.TabIndex = 10;
            this.btnImportEle.Text = "Import";
            this.btnImportEle.UseVisualStyleBackColor = true;
            this.btnImportEle.Click += new System.EventHandler(this.btnImportEle_Click);
            // 
            // btnBrowseEle
            // 
            this.btnBrowseEle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBrowseEle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseEle.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnBrowseEle.Location = new System.Drawing.Point(435, 28);
            this.btnBrowseEle.Name = "btnBrowseEle";
            this.btnBrowseEle.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseEle.TabIndex = 9;
            this.btnBrowseEle.Text = "Browse";
            this.btnBrowseEle.UseVisualStyleBackColor = true;
            this.btnBrowseEle.Click += new System.EventHandler(this.btnBrowseEle_Click);
            // 
            // txtFileEle
            // 
            this.txtFileEle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFileEle.Location = new System.Drawing.Point(138, 31);
            this.txtFileEle.Name = "txtFileEle";
            this.txtFileEle.Size = new System.Drawing.Size(291, 20);
            this.txtFileEle.TabIndex = 8;
            // 
            // cbEleDocument
            // 
            this.cbEleDocument.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbEleDocument.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEleDocument.FormattingEnabled = true;
            this.cbEleDocument.Location = new System.Drawing.Point(12, 30);
            this.cbEleDocument.Name = "cbEleDocument";
            this.cbEleDocument.Size = new System.Drawing.Size(120, 21);
            this.cbEleDocument.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label8.Location = new System.Drawing.Point(135, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "From";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label9.Location = new System.Drawing.Point(9, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Document";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.pictureBox1);
            this.pnlHeader.Controls.Add(this.lblImportSchema);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(830, 84);
            this.pnlHeader.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::FileViewer.Properties.Resources.addressbook;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 78);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblImportSchema
            // 
            this.lblImportSchema.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImportSchema.AutoSize = true;
            this.lblImportSchema.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImportSchema.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblImportSchema.Location = new System.Drawing.Point(67, 21);
            this.lblImportSchema.Name = "lblImportSchema";
            this.lblImportSchema.Size = new System.Drawing.Size(260, 40);
            this.lblImportSchema.TabIndex = 0;
            this.lblImportSchema.Text = "Import schema";
            this.lblImportSchema.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExportSchema
            // 
            this.btnExportSchema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportSchema.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnExportSchema.Location = new System.Drawing.Point(194, 429);
            this.btnExportSchema.Name = "btnExportSchema";
            this.btnExportSchema.Size = new System.Drawing.Size(85, 28);
            this.btnExportSchema.TabIndex = 14;
            this.btnExportSchema.Text = "Export";
            this.btnExportSchema.UseVisualStyleBackColor = true;
            this.btnExportSchema.Click += new System.EventHandler(this.btnExportSchema_Click);
            // 
            // ImportSchemas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 576);
            this.Controls.Add(this.panelForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportSchemas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import Schema";
            this.panelForm.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.ctrlTabImport.ResumeLayout(false);
            this.tabDocuments.ResumeLayout(false);
            this.tabDocuments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvDocument)).EndInit();
            this.tabGroups.ResumeLayout(false);
            this.tabGroups.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvGroupMap)).EndInit();
            this.tabSegments.ResumeLayout(false);
            this.tabSegments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvSegMap)).EndInit();
            this.tabElements.ResumeLayout(false);
            this.tabElements.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvEleMap)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblImportSchema;
        private System.Windows.Forms.CustomTabControl ctrlTabImport;
        private System.Windows.Forms.TabPage tabDocuments;
        private System.Windows.Forms.TabPage tabGroups;
        private System.Windows.Forms.TabPage tabSegments;
        private System.Windows.Forms.TabPage tabElements;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtDocId;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtDocType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grvDocument;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnImportGroup;
        private System.Windows.Forms.Button btnBrowseGroup;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.ComboBox cbDocument;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnImportSeg;
        private System.Windows.Forms.Button btnBrowseSeg;
        private System.Windows.Forms.TextBox txtFileSeg;
        private System.Windows.Forms.ComboBox cbSegDocument;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnImportEle;
        private System.Windows.Forms.Button btnBrowseEle;
        private System.Windows.Forms.TextBox txtFileEle;
        private System.Windows.Forms.ComboBox cbEleDocument;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView grvGroupMap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Source;
        private System.Windows.Forms.DataGridViewTextBoxColumn Target;
        private System.Windows.Forms.DataGridView grvSegMap;
        private System.Windows.Forms.DataGridView grvEleMap;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn SegSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn SegTarget;
        private System.Windows.Forms.Button btnImportSchema;
        private System.Windows.Forms.Button btnExportSchema;
    }
}