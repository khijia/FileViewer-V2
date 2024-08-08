using System;
using System.Drawing;
using System.Windows.Forms;

namespace FileViewer.Utility
{
    public class LineNumberTextBox : UserControl
    {
        private RichTextBox _richTextBox;
        private StatusStrip statusStrip1;
        private Panel _lineNumberPanel;

       public StatusStrip statusStrip;
       public ToolStripStatusLabel toolStripStatusLabel1;
       public ToolStripStatusLabel toolStripStatusLabel2;
        public ToolStripStatusLabel toolStripStatusLabel3;
        public event EventHandler TextChangedEvent;
        public event MouseEventHandler MouseDownEvent;
        public event KeyEventHandler KeyEvent;

        public LineNumberTextBox()
        {
            _richTextBox = new RichTextBox();
            _lineNumberPanel = new Panel();

            this.statusStrip = new StatusStrip();
            this.toolStripStatusLabel1 = new ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new ToolStripStatusLabel();

            _lineNumberPanel.Paint += LineNumberPanel_Paint;
            _lineNumberPanel.Dock = DockStyle.Left;
            _lineNumberPanel.Width = 40;
            _lineNumberPanel.BackColor = Color.WhiteSmoke;

            _richTextBox.Dock = DockStyle.Fill;
            _richTextBox.BorderStyle = BorderStyle.None;
            _richTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _richTextBox.WordWrap = false;
            _richTextBox.Multiline = true;
            _richTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;

            _richTextBox.VScroll += (sender, args) => _lineNumberPanel.Invalidate();
            _richTextBox.TextChanged += (sender, args) => {
                _lineNumberPanel.Invalidate();
                TextChangedEvent?.Invoke(this, args);
            };
            _richTextBox.MouseDown += (sender, args) =>
            {
                MouseDownEvent?.Invoke(this, args);
            };
            _richTextBox.MouseClick += (sender, args) =>
            {
                MouseDownEvent?.Invoke(this, args);
            };
            _richTextBox.KeyDown += (sender, args) =>
            {
                KeyEvent?.Invoke(this, args);
            };
            _richTextBox.Resize += (sender, args) => _lineNumberPanel.Invalidate();

            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip.Location = new System.Drawing.Point(0, 428);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(800, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip";

            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(120, 17);
            this.toolStripStatusLabel1.Text = "Ln 1, Col 1"; // Line and Column

            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(120, 17);
            this.toolStripStatusLabel2.Text = "Word Count: 0"; // Word count

            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(120, 17);
            this.toolStripStatusLabel3.Text = "UTF-8"; // Encoding

            Controls.Add(_richTextBox);
            Controls.Add(_lineNumberPanel);
            Controls.Add(this.statusStrip);

            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();

        }

        private void LineNumberPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(_lineNumberPanel.BackColor);

            int firstIndex = _richTextBox.GetCharIndexFromPosition(new Point(0, 0));
            int firstLine = _richTextBox.GetLineFromCharIndex(firstIndex);
            int firstLineY = _richTextBox.GetPositionFromCharIndex(firstIndex).Y;

            int lastIndex = _richTextBox.GetCharIndexFromPosition(new Point(0, _lineNumberPanel.ClientSize.Height));
            int lastLine = _richTextBox.GetLineFromCharIndex(lastIndex);

            for (int i = firstLine; i <= lastLine; i++)
            {
                int y = firstLineY + (_richTextBox.GetPositionFromCharIndex(_richTextBox.GetFirstCharIndexFromLine(i)).Y - firstLineY);
                e.Graphics.DrawString((i + 1).ToString(), _richTextBox.Font, Brushes.Gray, 0, y);
            }
        }

        public string Text
        {
            get { return _richTextBox.Text; }
            set { _richTextBox.Text = value; }
        }

        public new Font Font
        {
            get { return _richTextBox.Font; }
            set { _richTextBox.Font = value; }
        }

        public new Color BackColor
        {
            get { return _richTextBox.BackColor; }
            set { _richTextBox.BackColor = value; }
        }

        public int SelectionStart
        {
            get { return _richTextBox.SelectionStart; }
            set { _richTextBox.SelectionStart = value; }
        }

        public int GetLineFromCharIndex(int index)
        {
            return _richTextBox.GetLineFromCharIndex(index);
        }

        public int GetFirstCharIndexFromLine(int line)
        {
            return _richTextBox.GetFirstCharIndexFromLine(line);
        }
    }
}