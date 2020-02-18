using System;
using System.Collections.Generic;
using System.Text;

namespace csharp8.Functions
{
    class StackallocExpressions
    {
        public static void StackAllocEx(int size)
        {
            Span<byte> numbers = size <= 128 ? stackalloc byte[size] : new byte[size];

            Random rg = new Random(42);
            rg.NextBytes(numbers);

            ReadOnlySpan<byte> primesLTten = stackalloc byte[] { 1, 3, 5, 7 };
            var i = numbers.IndexOfAny(primesLTten);

            Console.WriteLine(i);
        }
    }
}
