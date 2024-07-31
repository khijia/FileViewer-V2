
using FileViewer.Utility;

namespace FileViewer.Forms
{
    partial class LineNumberTextBoxForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private LineNumberTextBox lineNumberTextBox;

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
            this.lineNumberTextBox = new LineNumberTextBox();
            this.SuspendLayout();
            // 
            // lineNumberTextBox
            // 
            this.lineNumberTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lineNumberTextBox.Location = new System.Drawing.Point(0, 0);
            this.lineNumberTextBox.Name = "lineNumberTextBox";
            this.lineNumberTextBox.Size = new System.Drawing.Size(800, 450);
            this.lineNumberTextBox.TabIndex = 0;

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lineNumberTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
        }

        #endregion
    }
}