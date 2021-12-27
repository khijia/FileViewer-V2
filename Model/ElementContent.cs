using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileViewer.Model
{
    public class ElementContent
    {
        public int Id { get; set; }
        public int LineNum { get; set; }
        public int ParentId { get; set; }
        public int DocumentId { get; set; }
        public int DocType { get; set; }
        public int ParentGroupId { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int GroupLevel { get; set; }
        public int GroupSequence { get; set; }
        public int SegmentId { get; set; }
        public int SegmentSequence { get; set; }
        public int ElementId { get; set; }
        public string ElementValue { get; set; }
        public string ElementName { get; set; }
        public string SegmentName { get; set; }
        public int StartAt { get; set; }
        public int Length { get; set; }
    }
}
