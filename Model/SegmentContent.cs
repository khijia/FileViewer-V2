
using System.Collections.Generic;

namespace FileViewer.Model
{
    public class SegmentContent
    {
        public int Index { get; set; }
        public string SegmentName { get; set; }
        public List<ElementContent> Elements { get; set; }
    }
}
