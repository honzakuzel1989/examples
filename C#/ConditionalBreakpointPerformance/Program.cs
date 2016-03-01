using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionalBreakpointPerformance
{
    class Program
    {
        static IList<string> GetItems(char c, int num)
        {
            //Generate num: of strings with 0-num c: character
            //for example (c='o', num=10):
            //"o"
            //"oo"
            //"ooo"
            //"oooo"
            //"ooooo"
            //"oooooo"
            //"ooooooo"
            //"oooooooo"
            //"ooooooooo"
            //"oooooooooo"

            StringBuilder b = new StringBuilder(num);
            IList<string> l = new List<string>();

            for (int i = 0; i < num; i++)
            {
                b.Append(c);
                l.Add(b.ToString());
            }

            return l;
        }

        static void Main(string[] args)
        {
            int nLoop = 10;
            long sum = 0;
            double avg = 0;
            IList<string> li = GetItems('x', 1000);

            for (int l = 0; l < nLoop; l++)
            {

                Stopwatch s = new Stopwatch();
                s.Start();

                string dummy = string.Empty;
                foreach (var i in li)
                {
                    // Delay
                    for (int x = 0; x < 10000; x++) ;
                    // Insert conditional breakpoint to the line bellow.. for example with condition string.IsNullOrWhiteSpace(i)
                    dummy = i;
                }

                sum += s.ElapsedMilliseconds;
                Console.WriteLine($"{s.ElapsedMilliseconds}ms");
                s.Stop();
                s.Reset();
            }

            avg = sum / (double)nLoop;
            Console.WriteLine($"{avg}ms");
            Console.ReadLine();

            //Results (64b i7-4702MQ @ 2.20Ghz, 8GB RAM, 500GB SSD):
            //without breakpoint: 28ms
            //with breakpoint: 1882ms
        }
    }
}
