using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait.WhenAll
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wait for it...");
            DateTime dtStart = DateTime.Now;
            WaitForAll(Task.Delay(1000), Task.Delay(2500), Task.Delay(5000)).Wait();
            DateTime dtEnd = DateTime.Now;
            // Something around 5000ms
            Console.WriteLine(dtEnd.Subtract(dtStart));
            Console.ReadLine();
        }

        static async Task WaitForAll(params Task[] tasks)
        {
            await Task.WhenAll(tasks);
        }
    }
}
