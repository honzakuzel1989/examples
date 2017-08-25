using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Original
{
    class Fraction
    {
        private static Dictionary<string, WeakReference<Fraction>> usedFractions = new Dictionary<string, WeakReference<Fraction>>();

        public static Fraction GetOrCreate(int numerator, int denominator)
        {
            Fraction fraction;
            WeakReference<Fraction> result;
            string key = $"{numerator}|{denominator}";

            if (usedFractions.TryGetValue(key, out result))
            {
                if (!result.TryGetTarget(out fraction))
                {
                    fraction = new Fraction(numerator, denominator);
                    usedFractions[key].SetTarget(fraction);
                }
            }
            else
            {
                fraction = new Fraction(numerator, denominator);
                usedFractions[key] = new WeakReference<Fraction>(fraction);
            }

            return fraction;
        }

        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        private Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;

            Console.WriteLine($"Create new fraction {Numerator}|{Denominator}");
        }

        public override string ToString()
        {
            return $"{Numerator}|{Denominator}";
        }
    }
}
