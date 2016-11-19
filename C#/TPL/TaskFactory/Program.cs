using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace TaskFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            // simple task
            Task.Factory.StartNew(simpleTask);

            // task synchronization
            var ft = Task.Factory.StartNew(firstTask);
            ft.Wait();
            var sd = Task.Factory.StartNew(secondTask);

            ft = Task.Factory.StartNew(firstTask);
            sd = Task.Factory.StartNew(secondTask);
            // WaitAll & WaitAny
            Task.WaitAll(ft, sd);

            ReadLine();
        }

        private static void secondTask()
        {
            WriteLine(nameof(secondTask));
            Thread.Sleep(2500);
        }

        private static void firstTask()
        {
            WriteLine(nameof(firstTask));
            Thread.Sleep(2500);
        }

        static void simpleTask()
        {
            WriteLine(nameof(simpleTask));
        }
    }
}
