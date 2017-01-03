using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;
using System.Diagnostics;

namespace ListsPerformance
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> l = null;
            ImmutableList<int> il = null;

            foreach (var N in new[] { 100, 1000, 10000, 100000, 1000000, 10000000 })
            {
                // init and fulfil list
                l = new List<int>(Enumerable.Range(0, N));

                // init and fulfil immutablelist
                il = ImmutableList<int>.Empty;
                il = il.InsertRange(0, Enumerable.Range(0, N));
                
                // O(N)
                Stopwatch s = Stopwatch.StartNew();
                foreach (var i in il)
                { int j = i; }
                s.Stop();
                Console.WriteLine(s.ElapsedMilliseconds);

                // O(log(N) * N)
                s = Stopwatch.StartNew();
                for (int i = 0; i < il.Count; i++)
                { int j = il[i]; }
                s.Stop();
                Console.WriteLine(s.ElapsedMilliseconds);
            }

            Console.ReadLine();
        }
    }
}
