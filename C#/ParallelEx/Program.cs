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
            Parallel.For(0, 1000, (i) =>
            {
                Console.WriteLine($"{i}:{Thread.CurrentThread.ManagedThreadId}");
            });

            // Waiting until finish each action - something like barrier (!)
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
