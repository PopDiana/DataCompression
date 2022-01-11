using DataCompression.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zstandard.Net;

namespace DataCompression.Algorithms
{
    class ZStandardCompression : ICompression, IParallelCompression
    {
        private int compressionLevel = 5;
        private FileStream inFileStream;
        private FileStream outFileStream;

        public string CompressedFileExtension => ".zstd";

        public int Compress(string inputURL, string outputURL)
        {
            inFileStream = new FileStream(inputURL, FileMode.Open, FileAccess.Read);
            outFileStream = new FileStream(outputURL + Path.GetFileNameWithoutExtension(inFileStream.Name) + CompressedFileExtension, FileMode.Create, FileAccess.Write);
            using (var compressionStream = new ZstandardStream(outFileStream, compressionLevel, true))
            {
                inFileStream.CopyTo(compressionStream);
            }
            var count = outFileStream.Length;
            inFileStream.Close();
            outFileStream.Close();
            return (int)count;
        }

        public void Compress(Stream source, Stream destination, int compressionLevel)
        {
            using (var compressionStream = new ZstandardStream(destination, compressionLevel, true))
            {
                source.CopyTo(compressionStream);
            }
        }

        public int Decompress(string inputURL, string outputURL)
        {
            using (var inFileStream = File.Open(inputURL, FileMode.Open))
            using (var outFileStream = File.Create(outputURL))
            using (var compressionStream = new ZstandardStream(inFileStream, CompressionMode.Decompress))
            {
                compressionStream.CopyTo(outFileStream);
            }
            return (int)new FileInfo(outputURL).Length;
        }
    }
}
