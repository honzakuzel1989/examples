using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DownloadFile
{
    class Program
    {
        static int lastPercentage = -1;
        static AutoResetEvent are = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
                wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
                Console.WriteLine($"Started...");
                wc.DownloadFileAsync(new Uri(@"http://mirror.internode.on.net/pub/test/10meg.test"), "10meg.test");

                are.WaitOne();
                Console.WriteLine($"Done...");
            }

            Console.ReadLine();
        }

        private static void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage > lastPercentage)
            {
                lastPercentage = e.ProgressPercentage;
                Console.WriteLine($"{e.BytesReceived}B ({e.ProgressPercentage}%)");
            }
        }

        private static void Wc_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Console.WriteLine($"Completed...");
            are.Set();
        }
    }
}
