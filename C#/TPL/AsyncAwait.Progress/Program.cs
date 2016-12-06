using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait.Progress
{
    class Program
    {
        static void Main(string[] args)
        {
            Progress<double> progress = new Progress<double>();
            progress.ProgressChanged += Progress_ProgressChanged;
            ReportProgressAsync(progress).Wait();
            Console.ReadLine();
        }

        private static void Progress_ProgressChanged(object sender, double e)
        {
            Console.Write($"\r{e}%\t\t");
        }

        static async Task ReportProgressAsync(IProgress<double> progress = null)
        {
            int max = 60;
            foreach (var i in Enumerable.Range(1, max))
            {
                await Task.Delay(500);
                progress?.Report(Math.Round(i * 100.0 / max, 2));
            }
        }
    }
}
