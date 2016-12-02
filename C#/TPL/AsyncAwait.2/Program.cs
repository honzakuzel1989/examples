using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using static System.Threading.Thread;

namespace AsyncAwait._2
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine($"1:{CurrentThread.NameOrId()}");
            Task.Run(() =>
            {
                //Thread.Sleep(5000);
                Task.Delay(5000).Wait();

                // Task.Run use new thread (from threadpool)
                WriteLine($"2:{CurrentThread.NameOrId()}");
            });
            WriteLine($"3:{CurrentThread.NameOrId()}");

            ReadLine();
        }
    }
    static class Ext
    {
        public static string NameOrId(this Thread t)
        {
            return string.IsNullOrEmpty(t.Name) ? t.ManagedThreadId.ToString() : t.Name;
        }
    }
}
