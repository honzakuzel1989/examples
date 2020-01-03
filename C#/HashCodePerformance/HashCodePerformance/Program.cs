using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HashCodePerformance
{
    class Program
    {
        //
        // Item 10 in more effective C# 7.0
        //

        static (string description, Func<int, int> func)[] hashinfos = new (string, Func<int, int>)[]
        {
            // Really bad distribution - count/1_000 for hash
            ("x % 1000", x => x % 1000),
            // Also very bad distribution - count/10_000 for hash
            ("x % 10_000", x => x % 10_000),
            // Bad distribution - count/100_000 for hash
            ("x % 100_000", x => x % 100_000),

            // Good distribution in this case
            ("x", x => x),
            // Integer's GetHashcode function
            ("x.GetHashcode()", x => x.GetHashCode()),
        };

        static void Main(string[] args)
        {
            // Check methods
            foreach (var (description, func) in hashinfos)
            {
                Console.WriteLine(description);

                // NOT very reasonable - do not use
                int count = 1_000_000;
                var dict = new Dictionary<Number, int>();
                var arr = new Number[count];

                // START
                Stopwatch sw = new Stopwatch();
                sw.Start();

                // Stores i indexed by Number
                for (int i = 0; i < count; i++)
                {
                    var number = new Number(i, func);

                    dict[number] = i;
                    arr[i] = number;
                }

                // Search - same search
                int numofsearch = 1_00_000;
                Random random = new Random(numofsearch);

                // After creating section
                Console.WriteLine(TimeSpan.FromMilliseconds(sw.ElapsedMilliseconds));
                sw.Restart();

                // Test logic - really stupid!
                long sum = 0;
                for (int i = 0; i < numofsearch; i++)
                {
                    // Get number as result from dictionary
                    var number = random.Next(0, count);
                    var result = dict[arr[number]];

                    // .. read result and usm
                    sum += result;
                }

                // STOP
                sw.Stop();
                // 50003907051 == sum
                Console.WriteLine(sum);

                // After logic section
                Console.WriteLine(TimeSpan.FromMilliseconds(sw.ElapsedMilliseconds));
                Console.WriteLine();
            }

            // Done
            Console.ReadLine();
        }
    }

    class Number
    {
        public int N { get; }
        private int HashCode { get; }

        public Number(int n, Func<int, int> hashcodeFunc)
        {
            N = n;
            HashCode = hashcodeFunc(n);
        }

        public override bool Equals(object obj)
        {
            return obj is Number n && n.N == N;
        }

        public override int GetHashCode()
        {
            return HashCode;
        }
    }
}
