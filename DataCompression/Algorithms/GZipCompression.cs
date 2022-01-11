using DataCompression.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCompression.Algorithms
{
    class GZipCompression : ICompression, IParallelCompression
    {
        private int compressionLevel = 0;
        private FileStream inFileStream;
        private FileStream outFileStream;

        public string CompressedFileExtension => ".gz";

        public int Compress(string inputURL, string outputURL)
        {
            inFileStream = new FileStream(inputURL, FileMode.Open, FileAccess.Read);
            outFileStream = new FileStream(outputURL + Path.GetFileNameWithoutExtension(inFileStream.Name) + CompressedFileExtension, FileMode.Create, FileAccess.Write);
            using (var compressionStream = new GZipStream(outFileStream, (CompressionLevel)compressionLevel, true))
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
            var compressionLevelInner = (CompressionLevel)compressionLevel;
            using (var compressionStream = new GZipStream(destination, compressionLevelInner, true))
            {
                source.CopyTo(compressionStream);
            }
        }

        public int Decompress(string inputURL, string outputURL)
        {
            using (var inFileStream = File.Open(inputURL, FileMode.Open))
            using (var outFileStream = File.Create(outputURL))
            using (var compressionStream = new GZipStream(inFileStream, CompressionMode.Decompress))
            {
                compressionStream.CopyTo(outFileStream);
            }
            return (int)new FileInfo(outputURL).Length;
        }
    }
}
