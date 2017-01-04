using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cancellation._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Do();

            Console.ReadLine();
        }

        static async void Do()
        {
            DateTime startDt = DateTime.Now;

            var cts = new CancellationTokenSource();
            var ct = cts.Token;

            // start task
            var task = DoAsync(ct);

            // wait
            await Task.Delay(2500);

            // cancel task after 2500ms
            cts.Cancel();

            try
            {
                // wait for task
                await task;
            }
            catch (OperationCanceledException)
            {
                // task canceled before it completed
                Console.WriteLine(nameof(OperationCanceledException));
            }

            DateTime endDt = DateTime.Now;

            // something around 2500ms
            Console.WriteLine(endDt.Subtract(startDt));
        }

        static async Task DoAsync(CancellationToken ct = default(CancellationToken))
        {
            await Task.Delay(5000, ct);
        }
    }
}
