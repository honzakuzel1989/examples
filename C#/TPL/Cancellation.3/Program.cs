using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cancellation._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Do();
            Console.ReadLine();
        }

        private static async void Do()
        {
            // cancel by timeot (after 2.5s)
            var token = new CancellationTokenSource(2500).Token;

            var startDt = DateTime.Now;

            try { await Task.Delay(int.MaxValue, token); }
            catch (OperationCanceledException) { }

            Console.WriteLine(DateTime.Now.Subtract(startDt));
        }
    }
}
