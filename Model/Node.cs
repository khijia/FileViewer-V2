using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileViewer
{
    public abstract class Node
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public int Parent { get; set; }
        public string Usage { get; set; }

    }
}
