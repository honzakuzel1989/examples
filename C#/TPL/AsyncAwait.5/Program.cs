using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait._5
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
        }

        static async Task MainAsync()
        {
            var tasks = Enumerable.Range(1, 10).Select(i => DelayAsync(i * 1000));

            // Synchronous for (!)
            // Wait
            //foreach (var t in tasks)
            //{
            //    var res = await t;
            //    Console.WriteLine(res);
            //}

            // Parallel for (!)
            // Doesnt wait
            //Parallel.ForEach(tasks, async t =>
            //{
            //    var res = await t;
            //    Console.WriteLine(res);
            //});

            // WhenAll (!)
            // Wait
            // Works much better in most of scenarios
            await Task.WhenAll(tasks.Select(async t => Console.WriteLine(await t)));

            Console.ReadLine();
        }

        static async Task<int> DelayAsync(int val)
        {
            await Task.Delay(val);
            return val;
        }
    }
}
