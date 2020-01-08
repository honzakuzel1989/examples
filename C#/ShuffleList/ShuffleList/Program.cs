using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ShuffleList
{
    class Item
    {
        public uint I { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var cnts = new int[] { 100_000, 1000_000, 10_000_000, 100_000_000 };

            foreach (var cnt in cnts)
            {
                Console.WriteLine("cnt: " + cnt);
                var items = Enumerable.Range(0, cnt).Select(i => new Item { I = (uint)i });

                var itemsa = items.ToArray();
                var itemsl = items.ToList();

                var sw = new Stopwatch();
                var shufflizer = new Shufflizer();

                foreach (var x in new IEnumerable<Item>[] { items, itemsa, itemsl })
                {
                    Console.WriteLine("type: " + x.GetType().Name);

                    foreach (var (name, method) in new (string, Func<IEnumerable<Item>, IEnumerable<Item>> )[] 
                    { 
                        ("Shuffle1", shufflizer.Shuffle1), 
                        ("Shuffle2", shufflizer.Shuffle2<Item>) })
                    {
                        Console.WriteLine(name);

                        sw.Start();

                        ulong sum = 0;
                        foreach (var item in method(x))
                            sum += item.I;

                        Console.WriteLine("sum: " + sum);
                        Console.WriteLine(TimeSpan.FromMilliseconds(sw.ElapsedMilliseconds));

                        sw.Stop();
                        sw.Reset();
                    }
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }

    // :)
    class Shufflizer
    {
        // Approach with better performance and (maybe) worse distribution (because of swap)
        public IEnumerable<T> Shuffle1<T>(IEnumerable<T> items)
        {
            var rand = new Random();
            var itemsa = items.ToArray();
            var lasti = itemsa.Length - 1;

            // O(N)
            foreach (var item in itemsa)
            {
                // Get rundom number in interval <0, lasti>
                var rn = rand.Next(0, lasti + 1);
                yield return itemsa[rn];

                // Swap items and decrement lastitem
                itemsa[rn] = itemsa[lasti];
                lasti--;
            }
        }

        // Basic and intuitive approach
        public IEnumerable<T> Shuffle2<T>(IEnumerable<T> items)
        {
            // O(OrderBy) = O(N*logN) average for quicksort, O(N2) worst case
            var rand = new Random();
            return items.Select(x => (value: x, rnd: rand.Next()))
                .OrderBy(item => item.rnd).Select(item => item.value);
        }
    }
}