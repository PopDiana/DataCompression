using DataCompression.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K4os.Compression.LZ4;
using K4os.Compression.LZ4.Streams;
using System.IO;

namespace DataCompression.Algorithms
{
    class LZ4Compression : ICompression, IParallelCompression
    {
        private int compressionLevel = 5;

        public string CompressedFileExtension => ".lz4";

        public int Compress(string inputURL, string outputURL)
        {
            var inFileStream = new FileStream(inputURL, FileMode.Open, FileAccess.Read);
            var outFileStream = new FileStream(outputURL + Path.GetFileNameWithoutExtension(inFileStream.Name) + CompressedFileExtension, FileMode.Create, FileAccess.Write);
            var settings = new LZ4EncoderSettings
            {
                CompressionLevel = (LZ4Level)compressionLevel
            };
            using (LZ4EncoderStream compressionStream = LZ4Stream.Encode(outFileStream, settings, true))
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
            var settings = new LZ4EncoderSettings
            {
                CompressionLevel = (LZ4Level)compressionLevel
            };
            using (LZ4EncoderStream compressionStream = LZ4Stream.Encode(destination, settings, true))
            {
                source.CopyTo(compressionStream);
            }
        }

        public int Decompress(string inputURL, string outputURL)
        {
            using (var source = LZ4Stream.Decode(File.OpenRead(inputURL)))
            using (var target = File.Create(outputURL))
            {
                source.CopyTo(target);
            }
            return (int)new FileInfo(outputURL).Length;
        }
    }
}
