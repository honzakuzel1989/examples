using System;

namespace RandomCubeThrow
{
    class Program
    {
        static void Main()
        {
            var cubenums = new int[] { 1, 2, 3, 4, 5, 6 };
            var counters = new uint[cubenums.Length];

            var min = cubenums[0];
            var max = cubenums[cubenums.Length - 1];

            var cnts = new int[] { 10, 100, 1000, 10_000, 100_000, 1000_000, 10_000_000, 100_000_000, 1000_000_000 };

            foreach (var cnt in cnts)
            {
                Console.WriteLine($"cnt:\t{cnt}");
                var rng = new Random();
                for (uint i = 0; i < cnt; i++)
                    counters[rng.Next(min, max + 1) - min]++;

                var avg = cnt / cubenums.Length;
                Console.WriteLine($"avg:\t{avg}");
                foreach (var num in cubenums)
                    Console.WriteLine($"{num}:\t{counters[num - min]}, " +
                        $"diff: {Math.Round(Math.Abs(avg - counters[num - min]) / (avg / 100.0), 4)}%");

                Array.Clear(counters, 0, counters.Length);
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
