using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp8.Functions
{
    class AsyncStreamConsumer<T>
    {
        // Readonly (!)
        private IReadOnlyList<T> data;
        private TimeSpan delay;

        public AsyncStreamConsumer(IEnumerable<T> data, TimeSpan delay)
        {
            // Immutable (!)
            this.data = new List<T>(data);
            this.delay = delay;
        }

        private async IAsyncEnumerable<T> GenerateData()
        {
            foreach (var d in data)
            {
                // Add delay
                await Task.Delay(delay);
                yield return d;
            }
        }

        internal async Task ConsumeStream()
        {
            // Print data to Console.out
            await foreach (var d in GenerateData())
            {
                Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: {d}");
            }
        }
    }
}
