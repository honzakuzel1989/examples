#define PAR

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PLINQ._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Enumerable.Range(1, 1000);
#if PAR
            var start = DateTime.Now;
            var powers = nums.AsParallel().Select(n => LongTermAction(n)).ToArray();
            var end = DateTime.Now;
            Console.WriteLine(end.Subtract(start));
#else
            // Someting around 50s
            var start = DateTime.Now;
            var powers = nums.Select(n => LongTermAction(n)).ToArray();
            var end = DateTime.Now;
            Console.WriteLine(end.Subtract(start));
#endif
            Console.ReadLine();
        }

        static int LongTermAction(int n)
        {
            Console.Write($"\rProcessing {n}\t\t\t\t\t");
            // CPU bound
            for (int i = 0; i < 100000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    int x = i * j + j;
                }
            }
            return n * n;
        }
    }
}
