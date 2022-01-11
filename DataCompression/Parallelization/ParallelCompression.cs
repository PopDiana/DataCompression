using DataCompression.Interfaces;
using DataCompression.Utils;
using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.IO;
using System.Threading.Tasks;

namespace DataCompression.Parallelization
{
    public class ParallelCompression : IParallelCompression
    {
        private readonly int _chunkSize;
        private readonly IProgress<int> _progress;
        private readonly IParallelCompression _wrappedCompressor;

        private readonly BlockingCollection<Chunk> _compressionChunks;
        public string CompressedFileExtension => _wrappedCompressor.CompressedFileExtension;


        public ParallelCompression(IParallelCompression wrappedCompressor, IProgress<int> progress, int chunkSize = 1 * Constants.Sizes.MB)
        {
            _wrappedCompressor = wrappedCompressor;
            _progress = progress;
            _chunkSize = chunkSize;

            int degreeOfParalelization = Environment.ProcessorCount;

            _compressionChunks = new BlockingCollection<Chunk>(degreeOfParalelization);
           
        }

        public ParallelCompression(IParallelCompression wrappedCompressor, IProgress<int> progress, int degreeOfParallelization, int chunkSize = 1 * Constants.Sizes.MB)
        {
            _wrappedCompressor = wrappedCompressor;
            _progress = progress;
            _chunkSize = chunkSize;

            _compressionChunks = new BlockingCollection<Chunk>(degreeOfParallelization);
 
        }
        public void Compress(Stream source, Stream destination, int compressionLevel)
        {
            Task readingTask = Task.Run(() => ReadSourceIntoChunksAndCompress(source, compressionLevel));

            Task mergingTask = Task.Run(() => MergeCompressedChunks(destination));

            Task.WaitAll(readingTask, mergingTask);
        }

        private async Task ReadSourceIntoChunksAndCompress(Stream source, int compressionLevel)
        {
            var count = 1;
            int bytesRead;
            ArrayPool<byte> arrayPool = ArrayPool<byte>.Shared;
            while (source.Position < source.Length)
            {
                byte[] buffer = arrayPool.Rent(_chunkSize);
                bytesRead = await source.ReadAsync(buffer, 0, _chunkSize);
                var chunk = new Chunk
                {
                    Index = count++,
                    InputStream = new MemoryStream(buffer, 0, bytesRead)
                };
                _compressionChunks.Add(chunk);
                Task _ = Task.Factory
                    .StartNew(() => CompressChunk(chunk, compressionLevel))
                    .ContinueWith(t => arrayPool.Return(buffer, true));


                _progress?.Report((int)(source.Position * 100 / source.Length));
            }

            _compressionChunks.CompleteAdding();
        }


        private void CompressChunk(Chunk chunk, int compressionLevel)
        {
            var output = new MemoryStream((int)chunk.InputStream.Length);
            _wrappedCompressor.Compress(chunk.InputStream, output, compressionLevel);
            chunk.OutputStream = output;
            chunk.Completed = true;
        }

        private async Task MergeCompressedChunks(Stream destination)
        {
            while (_compressionChunks.Count != 0 || !_compressionChunks.IsAddingCompleted)
            {
                Chunk chunk;
                if (!_compressionChunks.TryTake(out chunk, -1))
                {
                    await Task.Delay(1);
                    continue;
                }

                while (!chunk.Completed)
                    await Task.Delay(1);

                var length = (int)chunk.OutputStream.Length;
                await destination.WriteAsync(BitConverter.GetBytes(length), 0, 4);
                await destination.WriteAsync(chunk.OutputStream.GetBuffer(), 0, length);
            }
        }

    }
}
