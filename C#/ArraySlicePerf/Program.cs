using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySlicePerf
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Enumerable.Range(0, 100_000_000).ToArray();
            int[] skips = { 0, 1000, 10_000, 100_000, 1_000_000, 10_000_000, 100_000_000 };
            int[] lengths = skips.Reverse().ToArray();

            for (int i = 0; i < skips.Length; i++)
                Run(input, skips[i], lengths[i]);

            Console.ReadLine();
        }


        static void Run<T>(T[] inp, int skip, int length)
        {
            Console.WriteLine($"== elements: {inp.Length}, skip: {skip}, length: {length}");

            var methodsData = new (Func<T[], int, int, T[]> method, string name)[]
            {
                (ByLinq, nameof(ByLinq)),
                (ByArray, nameof(ByArray)),
                (BySpan, nameof(BySpan)),
                (ByHand, nameof(ByHand)),
            };

            Stopwatch sw = new Stopwatch();
            foreach (var md in methodsData)
            {
                sw.Start();
                var outp = md.method(inp, skip, length);
                Console.WriteLine($"method: {md.name}, outp: {outp.Length}, duration: {sw.ElapsedTicks}");
                sw.Reset();
            }
        }

        static T[] ByLinq<T>(T[] inp, int skip, int length)
        {
            return inp.Skip(skip).Take(length).ToArray();
        }

        static T[] ByArray<T>(T[] inp, int skip, int length)
        {
            T[] dest = new T[length];
            Array.Copy(inp, skip, dest, 0, length);
            return dest;
        }

        static T[] BySpan<T>(T[] inp, int skip, int length)
        {
            return new Span<T>(inp, skip, length).ToArray();
        }

        static T[] ByHand<T>(T[] inp, int skip, int length)
        {
            T[] dest = new T[length];
            for (int i = 0; i < length; i++)
                dest[i] = inp[skip + i];
            return dest;
        }
    }
}
