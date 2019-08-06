using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskWhenAll
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Cts
            var cts = new CancellationTokenSource();

            try
            {
                await Task.WhenAll(OpenDoorLeft(cts), OpenDoorRight(cts), MoveCart(cts), MoveDetector(cts));
                Console.WriteLine("Finished");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Failured");
            }
            finally
            {

                Console.ReadLine();
            }
        }

        static async Task OpenDoorLeft(CancellationTokenSource cts)
        {
            Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}] OpenDoorLeft - start");
            await Task.Delay(TimeSpan.FromSeconds(3), cts.Token);
            //await Delay(cts.Token, 30);
            Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}] OpenDoorLeft - done");
            await Task.CompletedTask;
        }

        static async Task OpenDoorRight(CancellationTokenSource cts)
        {
            Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}] OpenDoorRight - start");
            await Task.Delay(TimeSpan.FromSeconds(3), cts.Token);
            //await Delay(cts.Token, 30);

            // FAIL - cancel
            cts.Cancel();
        }

        static async Task MoveCart(CancellationTokenSource cts)
        {
            Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}] MoveCart - start");
            await Task.Delay(TimeSpan.FromSeconds(5), cts.Token);
            //await Delay(cts.Token, 50);
            Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}] MoveCart - done");
            await Task.CompletedTask;
        }

        static async Task MoveDetector(CancellationTokenSource cts)
        {
            Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}] MoveDetector - start");
            await Task.Delay(TimeSpan.FromSeconds(2), cts.Token);
            //await Delay(cts.Token, 20);
            Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}] MoveDetector - done");
            await Task.CompletedTask;
        }

        //private static async Task Delay(CancellationToken token, int x)
        //{
        //    for (int i = 0; i < x; i++)
        //    {
        //        // Own way
        //        //if (token.IsCancellationRequested)
        //        //    throw new TaskCanceledException();
        //        // TPL way
        //        token.ThrowIfCancellationRequested();
        //        // x * 100 ms
        //        await Task.Delay(TimeSpan.FromMilliseconds(100));
        //    }
        //}
    }
}
