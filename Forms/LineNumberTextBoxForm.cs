using FileViewer.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileViewer.Forms
{
    public partial class LineNumberTextBoxForm : Form
    {
        public LineNumberTextBoxForm()
        {
            InitializeComponent();
            LineNumberTextBox lineNumberTextBox = new LineNumberTextBox();
            lineNumberTextBox.Dock = DockStyle.Fill;
            this.Controls.Add(lineNumberTextBox);
        }
    }
}
