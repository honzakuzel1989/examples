using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ParallelTaskExecution
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Things to do
            var tasks = Enumerable.Range(1, 10).Select(i => DownloadPageAsync(i));

            // Seqentual run and Seqentual result
            DateTime startss = DateTime.Now;
            foreach (var t in tasks)
                await ProcessResult(await t);
            TimeSpan ss = DateTime.Now.Subtract(startss);

            // Parallel run and Seqentual result
            DateTime startsp = DateTime.Now;
            foreach (var str in await Task.WhenAll(tasks))
                await ProcessResult(str);
            TimeSpan sp = DateTime.Now.Subtract(startsp);
            
            // Parallel run and result
            DateTime startpp = DateTime.Now;
            await Task.WhenAll(tasks.Select(ProcessResult));
            TimeSpan pp = DateTime.Now.Subtract(startpp);

            // Durations
            Console.WriteLine();
            Console.WriteLine(ss);
            Console.WriteLine(sp);
            Console.WriteLine(pp);

            // --
            Console.ReadLine();
        }

        private static async Task ProcessResult(Task<(int, string)> t)
        {
            await ProcessResult(await t);
        }

        private static async Task ProcessResult((int i, string str) data)
        {
            // Delay, work takes time
            await Task.Delay(TimeSpan.FromSeconds(1));
            Console.WriteLine($"ProcessResult {data.i} of length {data.str.Length}");
        }

        static async Task<(int, string)> DownloadPageAsync(int i)
        {
            using (WebClient wc = new WebClient())
            {
                // Delay, my page is too small :)
                await Task.Delay(TimeSpan.FromSeconds(1));
                Console.WriteLine($"DownloadPageAsync {i}");
                return (i, await wc.DownloadStringTaskAsync(new Uri("http://www.honzakuzel.eu")));
            }
        }
    }
}
