using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Original
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create new fractions
            foreach (var i in Enumerable.Range(1, 100))
            {
                Fraction f = Fraction.GetOrCreate(1, i);
            }

            // --
            GC.Collect();

            // Recycle old fraction
            foreach (var i in Enumerable.Range(1, 100))
            {
                Fraction f = Fraction.GetOrCreate(1, i);
            }

            Console.ReadLine();
        }
    }
}
