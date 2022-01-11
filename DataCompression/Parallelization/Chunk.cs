using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCompression.Parallelization
{
    public class Chunk
    {
        public int Index { get; set; }
        public MemoryStream InputStream { get; set; }
        public MemoryStream OutputStream { get; set; }
        public bool Completed { get; set; }
    }
}
