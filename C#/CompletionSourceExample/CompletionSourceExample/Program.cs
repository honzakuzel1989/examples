using System;
using System.Threading;
using System.Threading.Tasks;

namespace CompletionSourceExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            DateTime start = DateTime.Now;
            var tcs = new TaskCompletionSource<bool>();
            // Never ends
            // var _ = Task.Delay(1000);//.ContinueWith(__ => tcs.SetResult(true));
            // Fire and forget task
            //var _ = Task.Delay(1000 * 5).ContinueWith(__ => tcs.SetResult(true));
            // Or thread (io operation, whatever)
            new Thread(() => 
            {
                Thread.Sleep(5000);
                // !
                tcs.SetResult(true);
                // --
            }).Start();
            // Stops here
            await tcs.Task;
            Console.WriteLine(DateTime.Now.Subtract(start));

            Console.ReadLine();
        }
    }
}
