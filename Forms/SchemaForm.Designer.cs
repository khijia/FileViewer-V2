
namespace FileViewer
{
    partial class SchemaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchemaForm));
            this.grvSchema = new System.Windows.Forms.DataGridView();
            this.cbDocument = new System.Windows.Forms.ComboBox();
            this.cbGroup = new System.Windows.Forms.ComboBox();
            this.cbSegment = new System.Windows.Forms.ComboBox();
            this.cbElement = new System.Windows.Forms.ComboBox();
            this.lblDocument = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grvSchema)).BeginInit();
            this.SuspendLayout();
            // 
            // grvSchema
            // 
            this.grvSchema.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grvSchema.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvSchema.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.grvSchema.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvSchema.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grvSchema.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvSchema.GridColor = System.Drawing.SystemColors.ControlLight;
            this.grvSchema.Location = new System.Drawing.Point(12, 48);
            this.grvSchema.Name = "grvSchema";
            this.grvSchema.ReadOnly = true;
            this.grvSchema.RowTemplate.ReadOnly = true;
            this.grvSchema.Size = new System.Drawing.Size(977, 572);
            this.grvSchema.TabIndex = 3;
            // 
            // cbDocument
            // 
            this.cbDocument.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbDocument.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDocument.FormattingEnabled = true;
            this.cbDocument.Location = new System.Drawing.Point(13, 21);
            this.cbDocument.Name = "cbDocument";
            this.cbDocument.Size = new System.Drawing.Size(121, 21);
            this.cbDocument.TabIndex = 4;
            this.cbDocument.SelectedIndexChanged += new System.EventHandler(this.cbDocument_SelectedIndexChanged);
            // 
            // cbGroup
            // 
            this.cbGroup.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGroup.FormattingEnabled = true;
            this.cbGroup.Location = new System.Drawing.Point(140, 21);
            this.cbGroup.Name = "cbGroup";
            this.cbGroup.Size = new System.Drawing.Size(170, 21);
            this.cbGroup.TabIndex = 4;
            this.cbGroup.SelectedIndexChanged += new System.EventHandler(this.cbGroup_SelectedIndexChanged);
            // 
            // cbSegment
            // 
            this.cbSegment.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbSegment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSegment.FormattingEnabled = true;
            this.cbSegment.Location = new System.Drawing.Point(316, 21);
            this.cbSegment.Name = "cbSegment";
            this.cbSegment.Size = new System.Drawing.Size(170, 21);
            this.cbSegment.TabIndex = 4;
            this.cbSegment.SelectedIndexChanged += new System.EventHandler(this.cbSegment_SelectedIndexChanged);
            // 
            // cbElement
            // 
            this.cbElement.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbElement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbElement.FormattingEnabled = true;
            this.cbElement.Location = new System.Drawing.Point(494, 21);
            this.cbElement.Name = "cbElement";
            this.cbElement.Size = new System.Drawing.Size(170, 21);
            this.cbElement.TabIndex = 4;
            this.cbElement.SelectedIndexChanged += new System.EventHandler(this.cbElement_SelectedIndexChanged);
            // 
            // lblDocument
            // 
            this.lblDocument.AutoSize = true;
            this.lblDocument.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblDocument.Location = new System.Drawing.Point(12, 5);
            this.lblDocument.Name = "lblDocument";
            this.lblDocument.Size = new System.Drawing.Size(56, 13);
            this.lblDocument.TabIndex = 5;
            this.lblDocument.Text = "Document";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label2.Location = new System.Drawing.Point(137, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Group";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label3.Location = new System.Drawing.Point(313, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Segments";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label4.Location = new System.Drawing.Point(491, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Elements";
            // 
            // SchemaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1001, 632);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbDocument);
            this.Controls.Add(this.grvSchema);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblDocument);
            this.Controls.Add(this.cbGroup);
            this.Controls.Add(this.cbElement);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbSegment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SchemaForm";
            this.Text = "Schemas";
            ((System.ComponentModel.ISupportInitialize)(this.grvSchema)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

      

        #endregion

        private System.Windows.Forms.DataGridView grvSchema;
        private System.Windows.Forms.ComboBox cbDocument;
        private System.Windows.Forms.ComboBox cbGroup;
        private System.Windows.Forms.ComboBox cbSegment;
        private System.Windows.Forms.ComboBox cbElement;
        private System.Windows.Forms.Label lblDocument;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}