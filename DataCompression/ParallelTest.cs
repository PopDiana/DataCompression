using DataCompression.Algorithms;
using DataCompression.Interfaces;
using DataCompression.Parallelization;
using DataCompression.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCompression
{
    public static class ParallelTest
    {
        public static void Run()
        {
            string dirPath = @"";

            int[] chunkSizes = { 1 * Constants.Sizes.MB, 2 * Constants.Sizes.MB, 3 * Constants.Sizes.MB, 5 * Constants.Sizes.MB, 1 * Constants.Sizes.GB };
            int[] degreesOfParalelization = { Environment.ProcessorCount };
            var compressorsAndCompressionLevels = new List<(IParallelCompression, int[])>
            {                       
                (new GZipCompression(), new[] {2, 1, 0}),
                (new DeflateCompression(), new[] {2, 1, 0}),
                (new LZ4Compression(), new[] {0, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12}),           
                (new ZStandardCompression(), new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22})
            };

           foreach (var (compression, compressionLevels) in compressorsAndCompressionLevels)
                foreach (int degreeOfParalelization in degreesOfParalelization)
                    foreach (int chunkSize in chunkSizes)
                        foreach (int compressionlevel in compressionLevels)
                        {
                            var sw = new Stopwatch();
                            var mw = new MemoryWatch();

                            File.Delete(Path.Combine(dirPath, "compressed.txt"));

                            using (var input = new FileStream(Path.Combine(dirPath, "test.txt"), FileMode.Open, FileAccess.Read, FileShare.Read))
                            using (var compressed = new FileStream(Path.Combine(dirPath, "compressed.file"), FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
                            {
                                var parallelCompressor = new ParallelCompression(compression, null, degreeOfParalelization, chunkSize);

                                sw.Start();
                                mw.Start();
                                parallelCompressor.Compress(input, compressed, compressionlevel);
                                mw.Stop();
                                sw.Stop();                             
                                Console.WriteLine($"ParallelCompressor: {compression.GetType().Name} ChunkSize: {chunkSize} Parallelization: {degreeOfParalelization} CompressLevel: {compressionlevel} CompressRatio: {(double)input.Length / compressed.Length} Speed: {sw.Elapsed.TotalMilliseconds} MemMAX: {mw.MaximumMemoryAllocation} MemAVG: {mw.AverageMemoryAllocation}");
                            }
                        }

            foreach (var (compression, compressionLevels) in compressorsAndCompressionLevels)
                foreach (int compressionlevel in compressionLevels)
                {
                    var sw = new Stopwatch();
                    var mw = new MemoryWatch();

                    File.Delete(Path.Combine(dirPath, "compressed.txt"));

                    using (var input = new FileStream(Path.Combine(dirPath, "test.txt"), FileMode.Open, FileAccess.Read, FileShare.Read))
                    using (var compressed = new FileStream(Path.Combine(dirPath, "compressed.file"), FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
                    {
                        sw.Start();
                        mw.Start();
                        compression.Compress(input, compressed, compressionlevel);
                        mw.Stop();
                        sw.Stop();                   
                        Console.WriteLine($"Compressor: {compression.GetType().Name} ChunkSize: {0} Parallelization: {0} CompressLevel: {compressionlevel} CompressRatio: {(double)input.Length / compressed.Length} Speed: {sw.Elapsed.TotalMilliseconds} MemMAX: {mw.MaximumMemoryAllocation} MemAVG: {mw.AverageMemoryAllocation}");
                    }
                }
        }
    }
}
