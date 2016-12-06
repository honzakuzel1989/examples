using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait.WhenAny
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wait for it...");
            DateTime dtStart = DateTime.Now;
            WaitForAny(Task.Delay(1000), Task.Delay(2500), Task.Delay(5000)).Wait();
            DateTime dtEnd = DateTime.Now;
            // Something around 1000ms
            Console.WriteLine(dtEnd.Subtract(dtStart));
            Console.ReadLine();
        }

        static async Task WaitForAny(params Task[] tasks)
        {
            await Task.WhenAny(tasks);
        }
    }
}
