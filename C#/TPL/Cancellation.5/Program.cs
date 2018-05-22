using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cancellation._5
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;
            CancellationTokenSource cts = new CancellationTokenSource(2500);

            while (true)
            {
                // Cancelled after 2500ms
                if (cts.IsCancellationRequested)
                    break;
            }

            Console.WriteLine(DateTime.Now.Subtract(start));
            Console.ReadLine();
        }
    }
}
