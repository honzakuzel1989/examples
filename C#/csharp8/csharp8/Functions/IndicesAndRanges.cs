using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csharp8.Functions
{
    class IndicesAndRanges
    {
        private int[] data = Enumerable.Range(1, 10).ToArray();

        internal void PrintExamples()
        {
            // Indexes
            var first = 0;
            var last = ^1;

            Console.WriteLine(data[first]);
            Console.WriteLine(data[last]);

            // Range
            var end = ^1;
            var start = ^5;

            // Slice
            Console.WriteLine();
            foreach (var d in data[start..end])
            {
                Console.WriteLine(d);
            }

            end = ^5;
            start = 1;

            // Slice
            Console.WriteLine();
            foreach (var d in data[start..end])
            {
                Console.WriteLine(d);
            }

            // Not allowed because in Range is min > max check
            //foreach (var d in data[end..start])
            //{
            //    Console.WriteLine(d);
            //}

            // To end - start in inclusive
            Console.WriteLine();
            foreach (var d in data[1..])
            {
                Console.WriteLine(d);
            }

            // From start - end is exclusive
            Console.WriteLine();
            foreach (var d in data[..^1])
            {
                Console.WriteLine(d);
            }

            // Whole collection
            Console.WriteLine();
            foreach (var d in data[..])
            {
                Console.WriteLine(d);
            }
        }
    }
}
