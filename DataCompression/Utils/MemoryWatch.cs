using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataCompression.Utils
{
    public class MemoryWatch
    {
        private CancellationTokenSource _cancellationTokenSource;
        private int _count;
        private long _sum;

        public long MaximumMemoryAllocation { get; private set; }
        public long MinimumMemoryAllocation { get; private set; }
        public long AverageMemoryAllocation { get; private set; }

        public void Start()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _count = 1;
            _sum = 0;
            Task.Factory.StartNew(CollectMemory, _cancellationTokenSource.Token);
        }

        public void Stop()
        {
            _cancellationTokenSource.Cancel();
        }

        private async Task CollectMemory()
        {
            while (!_cancellationTokenSource.Token.IsCancellationRequested)
            {
                long memory = GC.GetTotalMemory(false);

                if (memory < MinimumMemoryAllocation)
                    MinimumMemoryAllocation = memory;

                if (memory > MaximumMemoryAllocation)
                    MaximumMemoryAllocation = memory;

                _count++;
                _sum += memory;
                AverageMemoryAllocation = _sum / _count;

                await Task.Delay(100);
            }
        }
    }
}
