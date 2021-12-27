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
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            var str = "This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the KJ; either version 2 of the License, or (at your option) any later version.\r\n\r\n";
            str += "This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.\r\n\r\n";
            str += "Thank you,\r\n";
            str += "KJ";
            richTextBox1.Text = str;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
