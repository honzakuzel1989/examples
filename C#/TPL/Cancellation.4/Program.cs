using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cancellation._4
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
            try
            {
                await DownloadStringAsync(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static async Task DownloadStringAsync(int timeout = 60)
        {
            using (var c = new WebClient())
            {
                using (new CancellationTokenSource(timeout * 1000).Token.Register(() => c.CancelAsync()))
                {
                    await c.DownloadFileTaskAsync(@"http://honzakuzel.eu/pic/gmail.png", "gmail.png");
                    Console.WriteLine("Done");
                }
            }
        }
    }
}
