using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
using static System.Console;
using System.Threading;

namespace ParallelExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // simple parallel loop
            Parallel.For(0, 33, CalculatePower2);

            // simple parallel loop with ParallelOptions
            Parallel.For(0, 65, new ParallelOptions { MaxDegreeOfParallelism = 4 }, CalculatePower2);

            // simple parallel foreach loop
            Parallel.ForEach(Enumerable.Range(0, 33), CalculatePower2);

            // invoke some actions
            Parallel.Invoke(
                    () => { WriteLine("Invoke 1"); },
                    () => { WriteLine("Invoke 2"); },
                    () => { WriteLine("Invoke 3"); },
                    () => { WriteLine("Invoke 4"); },
                    () => { WriteLine("Invoke 5"); },
                    () => { WriteLine("Invoke 6"); },
                    () => { WriteLine("Invoke 7"); }
                );

            // parralel loop with result
            ParallelLoopResult lr = Parallel.ForEach(Enumerable.Range(0, 17), CalculatePower2WithSleep);
            WriteLine($"IsCompleted={lr.IsCompleted}");

            ReadLine();
        }

        private static void CalculatePower2WithSleep(int y)
        {
            WriteLine(Pow(2, y));
            Thread.Sleep(1000);
        }

        private static void CalculatePower2(int y)
        {
            WriteLine(Pow(2, y));
        }
    }
}
