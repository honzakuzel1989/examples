using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cancellation._2
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
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            var task = DoAsync(token);
            await Task.Delay(5000);
            cts.Cancel();

            try { await task; }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Canceled");
            }
        }

        private static Task DoAsync(CancellationToken token)
        {
            return Task.Run(() =>
            {
                for (int i = 0; i < int.MaxValue; i++)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(i + 1);
                    token.ThrowIfCancellationRequested();
                }
            });
        }
    }
}
