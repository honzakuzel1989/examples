using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainsPerformance
{
    class Program
    {
        // TODO: StackOverflow?
        class Foo
        {
            public bool Is { get; set; }
        }

        static void Main(string[] args)
        {
            var range1 = Enumerable.Range(0, 10000).Select(_ => new Foo());
            var range2 = Enumerable.Range(0, range1.Count() * 10).Select(_ => new Foo());

            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();

            foreach (var x in range2)
            {
                if (range1.Contains(x))
                    x.Is = true;
                else
                    x.Is = false;
            }

            sw.Stop();
            Console.WriteLine($"\t{sw.ElapsedMilliseconds}ms elapsed");

            sw = System.Diagnostics.Stopwatch.StartNew();

            foreach (var x in range2)
            {
                x.Is = false;
            }

            foreach (var x in range1)
            {
                x.Is = false;
            }

            sw.Stop();
            Console.WriteLine($"\t{sw.ElapsedMilliseconds}ms elapsed");

            Console.ReadLine();
        }
    }
}
