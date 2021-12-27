
namespace FileViewer
{
    public class Element: Node
    {
        public int SegmentId { get; set; }
        public int Document { get; set; }
        public int Length { get; set; }
        public int StartAt { get; set; }
        public string  Description { get; set; }
        public Element()
        {

        }
    }
}
