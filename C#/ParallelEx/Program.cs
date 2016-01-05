using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelEx
{
    class Program
    {
        static void Body()
        {
            // Print for index and thread id
            var res = Parallel.For(0, 100, (i) =>
            {
                Console.WriteLine($"{i}:{Thread.CurrentThread.ManagedThreadId}");
            });

            // Always true and null (in this case)
            Console.WriteLine($"{res.IsCompleted} ({res.LowestBreakIteration})");

            // Waiting until finish each action - something like barrier (!)

            res = new ParallelLoopResult();
            res = Parallel.For(0, 100, (i, p) =>
            {
                Console.WriteLine($"{i}:{Thread.CurrentThread.ManagedThreadId}");
                // Stop beyond the current iteration
                if (i == 10) p.Break();
                if (p.ShouldExitCurrentIteration) Console.WriteLine($"{i}:Should exit, {p.LowestBreakIteration}");
            });

            // False, of course, and empty lowest break iteration = 10
            Console.WriteLine($"{res.IsCompleted} ({res.LowestBreakIteration})");

            res = new ParallelLoopResult();
            res = Parallel.For(0, 20, (i, p) =>
            {
                Console.WriteLine($"{i}:{Thread.CurrentThread.ManagedThreadId}");
                // Stop as soon as possible
                if (i == 10) p.Stop();
                if (p.IsStopped) Console.WriteLine($"{i}:Stopped");
            });

            // False, of course, and empty
            Console.WriteLine($"{res.IsCompleted} ({res.LowestBreakIteration})");

            res = new ParallelLoopResult();
            res = Parallel.For(0, 200, new ParallelOptions { MaxDegreeOfParallelism = 3, }, (i) =>
            {
                Console.WriteLine($"{i}:{Thread.CurrentThread.ManagedThreadId}");
            });

            Parallel.For(0, 100,
                // Init - for each task
                () => { return 0; },
                // Body - for each loop
                (index, _, init) => 
                {
                    Console.WriteLine($"{index}:{Thread.CurrentThread.ManagedThreadId}");
                    init++;
                    return init;
                },
                // Final - for each task
                (result) => { Console.WriteLine($"Final result = {result}:{Thread.CurrentThread.ManagedThreadId}"); });
        }



        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main";

            Body();

            Console.WriteLine($"{Thread.CurrentThread.Name}");
            Console.ReadLine();
        }
    }
}
