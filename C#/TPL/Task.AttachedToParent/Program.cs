using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace TaskAttachedToParent
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = DateTime.Now;
            var t = Task.Factory.StartNew(() =>
            {
                WriteLine("Run parent..");
                Do();
                Thread.Sleep(2500);
                WriteLine("Parent done..");
            },
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskScheduler.Default);
            // Wait for task and all attached tasks
            t.Wait();
            var end = DateTime.Now;

            Console.WriteLine(end.Subtract(start));
            Console.ReadLine();
        }

        static void Do()
        {
            Task.Factory.StartNew(() =>
            {
                WriteLine("Run child..");
                Thread.Sleep(5000);
                WriteLine("Child done..");
            },
                CancellationToken.None,
                TaskCreationOptions.AttachedToParent,
                TaskScheduler.Default);

            Task.Factory.StartNew(() =>
            {
                WriteLine("Run child..");
                Thread.Sleep(7500);
                WriteLine("Child done..");
            },
                CancellationToken.None,
                TaskCreationOptions.AttachedToParent,
                TaskScheduler.Default);
        }
    }
}
