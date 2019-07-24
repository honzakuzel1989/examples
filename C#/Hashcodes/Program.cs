using System;
using System.Collections.Generic;

namespace Hashcodes
{
    class Multiplier
    {
        string Designation { get; } = Guid.NewGuid().ToString();

        public Multiplier(int a, int b)
        {
            Result = a * b;
        }

        int Result { get; }

        // Try it with uncommented part below

        //public override int GetHashCode()
        //{
        //    return Result.GetHashCode();
        //}

        //// Equals method is required
        //public override bool Equals(object obj)
        //{
        //    return obj is Multiplier m && m.Result == Result;
        //    //return obj != null && obj.GetHashCode() == GetHashCode();
        //}

        //public override string ToString()
        //{
        //    return Result.ToString();
        //}
    }

    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<Multiplier, int>();

            var f = new Multiplier(3, 5);
            var s = new Multiplier(5, 3);
            var t = new Multiplier(5, 3);

            Console.WriteLine("Hashcodes:");
            Console.WriteLine(f.GetHashCode());
            Console.WriteLine(s.GetHashCode());
            Console.WriteLine(t.GetHashCode());

            Console.WriteLine("Counts:");
            dict[f] = 1;
            Console.WriteLine(dict.Count);
            dict[s] = 2;
            Console.WriteLine(dict.Count);
            dict[t] = 3;
            Console.WriteLine(dict.Count);

            Console.WriteLine("Get second one:");
            Console.WriteLine(dict[s]);
            Console.ReadLine();
        }
    }
}
