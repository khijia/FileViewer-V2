namespace FileViewer
{
    public class Segment: Node
    {
        public int DocumentId { get; set; }
        public int GroupId { get; set; }
        public int FirstSegment { get; set; }
        public Segment()
        {

        }
    }
}
