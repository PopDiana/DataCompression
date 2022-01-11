using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCompression.Interfaces
{
    public interface IParallelCompression
    {
        string CompressedFileExtension { get; }

        void Compress(Stream source, Stream destination, int compressionLevel);
    }
}
