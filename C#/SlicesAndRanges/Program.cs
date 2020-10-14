using System;
using System.Linq;

namespace SlicesAndRanges
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Enumerable.Range(1, 32).ToArray();

            Console.WriteLine(string.Join(", ", numbers));

            // same as 0
            var firstFromStart = new Index(0);
            Console.WriteLine($"first = {numbers[firstFromStart]}");

            // same as numbers.Length - 1
            var lastFromStart = new Index(numbers.Length - 1);
            Console.WriteLine($"last = {numbers[lastFromStart]}");

            // same as numbers.Length - numbers.Length = 0
            var firstFromEnd = new Index(numbers.Length, true);
            Console.WriteLine($"first = {numbers[firstFromEnd]}");

            // same as numbers.Length - 1
            var lastFromEnd = new Index(1, true);
            Console.WriteLine($"last = {numbers[lastFromEnd]}");

            // or .., or 0.., or ..^1
            var firtsToLast = 0..^1;
            Console.WriteLine($"first to last = {string.Join(", " ,numbers[firtsToLast])}");

            // or ..5, like [0], ..., [5]
            var firtsFive = 0..5;
            Console.WriteLine($"first five = {string.Join(", ", numbers[firtsFive])}");

            // or ^6.., like [numbers.Length - 6], ..., [numbers.Length - 1]
            var lastFive = ^6..^1;
            Console.WriteLine($"last five = {string.Join(", ", numbers[lastFive])}");

            // or ..(numbers.Length / 2)
            var firstHalf = 0..(numbers.Length / 2);
            Console.WriteLine($"first half = {string.Join(", ", numbers[firstHalf])}");

            // or (numbers.Length / 2)..
            var lastHalf = (numbers.Length / 2)..^1;
            Console.WriteLine($"first half = {string.Join(", ", numbers[lastHalf])}");

            Console.ReadLine();
        }
    }
}
