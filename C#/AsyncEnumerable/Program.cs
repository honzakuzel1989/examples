using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncEnumerable
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await foreach (var dataPoint in FetchIOTData())
            {
                Console.WriteLine(dataPoint);
            }

            Console.ReadLine();
        }

        static async IAsyncEnumerable<int> FetchIOTData()
        {
            for (int i = 1; i <= 10; i++)
            {
                await Task.Delay(1000);
                yield return i;
            }
        }
    }
}
