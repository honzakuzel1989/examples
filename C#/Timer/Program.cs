using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TimerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer t = new Timer();
            t.Interval = 1000;
            t.Elapsed += (_, __) =>
            {
                Console.WriteLine(DateTime.Now.ToLongTimeString());
                System.Threading.Thread.Sleep(1000);
            };
            t.Start();

            Console.WriteLine(DateTime.Now);
            Console.ReadLine();
        }
    }
}
