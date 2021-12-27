using FileViewer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileViewer
{
    public partial class SchemaForm : Form
    {
        private List<Group> _group { get; set; }
        public List<Segment> _segment { get; set; }

        public SchemaForm()
        {
            InitializeComponent();
            LoadDocuments();
            grvSchema.RowPrePaint += GrvSchema_RowPrePaint;
            if (!SystemInformation.TerminalServerSession)
            {
                Type dgvType = grvSchema.GetType();
                PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(grvSchema, true, null);
            }
        }

        private void GrvSchema_RowPrePaint(object sender, System.Windows.Forms.DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                grvSchema.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Beige;
            }
        }

        private void cbDocument_SelectedIndexChanged(object sender, EventArgs e)
        {
            var docSelect = ((Document)cbDocument.SelectedItem).Id;
            LoadGroups(docSelect);
        }

        private void cbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            var groupSelect = ((Group)cbGroup.SelectedItem);
            var docTypeSelect = ((Document)cbDocument.SelectedItem);
            var groupId = groupSelect.Id;
            LoadSegments(docTypeSelect.Id, groupId);
        }
        private void cbSegment_SelectedIndexChanged(object sender, EventArgs e)
        {
            var segSelect = ((Segment)cbSegment.SelectedItem);
            var docTypeSelect = ((Document)cbDocument.SelectedItem);
            var segmentIds = new List<int>();
            if (segSelect.Id == -1)
            {
                var segmentSource = cbSegment.DataSource as List<Segment>;
                segmentSource.ForEach(x => { segmentIds.Add(x.Id); });
            }
            else
            {
                segmentIds.Add(segSelect.Id);
            }
            LoadElements(docTypeSelect.Id, segmentIds);
        }

        private void cbElement_SelectedIndexChanged(object sender, EventArgs e)
        {
            var eleSelect = ((Element)cbElement.SelectedItem);
            var docSelect = ((Document)cbDocument.SelectedItem);
            var groupSelect = ((Group)cbGroup.SelectedItem);
            var segSelect = ((Segment)cbSegment.SelectedItem);
            var segmentIds = new List<int>();
            if (segSelect.Id == -1)
            {
                var segmentSource = cbSegment.DataSource as List<Segment>;
                segmentSource.ForEach(x => { segmentIds.Add(x.Id); });
            }
            else
            {
                segmentIds.Add(segSelect.Id);
            }
            var elements = SchemaModel.LoadElementById(docSelect.Id, groupSelect.Id, segmentIds, eleSelect.Id);
            LoadDataGrid(elements);
        }

        #region Events
        private void LoadGroups(int docId)
        {
            _group = SchemaModel.LoadGroupsByDocumentId(docId);
            var bindingSource1 = new BindingSource();
            _group.Insert(0, new Group { Name = "-All-", Id = -1 });
            bindingSource1.DataSource = _group;
            cbGroup.DataSource = bindingSource1.DataSource;
            cbGroup.DisplayMember = "Name";
            cbGroup.ValueMember = "Id";
        }

        private void LoadSegments(int docId, int groupId)
        {
            _segment = (List<Segment>)SchemaModel.LoadSegmentByDGId(docId, groupId);
            var bindingSource1 = new BindingSource();
            _segment.Insert(0, new Segment { Name = "-All-", Id = -1 });
            bindingSource1.DataSource = _segment;
            cbSegment.DataSource = bindingSource1.DataSource;
            cbSegment.DisplayMember = "Name";
            cbSegment.ValueMember = "Id";
        }

        private void LoadElements(int docId, List<int> segmentId)
        {
            var elements = (List<Element>)SchemaModel.LoadElementsByDGE(docId, segmentId);
            var bindingSource1 = new BindingSource();
            elements.Insert(0, new Element { Name = "-All-", Id = -1 });
            bindingSource1.DataSource = elements;
            cbElement.DataSource = bindingSource1.DataSource;
            cbElement.DisplayMember = "Name";
            cbElement.ValueMember = "Id";
            LoadDataGrid(elements);
        }
        #endregion Events
        private void LoadDocuments()
        {
            var lstDoc = SchemaModel.LoadDocumentFromLib();
            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = lstDoc;
            cbDocument.DataSource = bindingSource1.DataSource;
            cbDocument.DisplayMember = "DocType";
            cbDocument.ValueMember = "Id";
        }

        private void LoadDataGrid(List<Element> elements)
        {
            var data = new List<DataSchema>();
            int count = 1;
            Dictionary<int, Group> groupExist = new Dictionary<int, Group>();
            Dictionary<int, Segment> segmentExist = new Dictionary<int, Segment>();
            string segmentName = string.Empty;
            Segment segment = null;
            Group group = null;
            elements.ForEach(ele =>
            {
                if (ele.Id == -1) return;
                var segmentId = ele.SegmentId;
                segment = _segment.Where(x => x.Id == segmentId)
                                      .Select(x => x)
                                      .FirstOrDefault();
                if (segment == null)
                    return;
                segmentName = segment.Name;

                group = _group.Where(x => x.Id == segment.GroupId)
                                      .Select(x => x)
                                      .FirstOrDefault();
                if (group == null) return;
                var groupName = group.Name;

                data.Add(new DataSchema
                {
                    No = count++,
                    //DocumentId = ele.Document,
                    GroupName = groupName,
                    SegmentName = segmentName,
                    Name = ele.Name,
                    Usage = ele.Usage,
                    //Parent = group.Parent,
                    Length = ele.Length,
                    StartAt = ele.StartAt,
                    Description = ele.Description
                });
            });
            grvSchema.DataSource = data;
        }
    }
}
