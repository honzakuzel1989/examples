using System;
using System.Collections.Generic;
using System.Text;

namespace csharp8.Functions
{
    struct ReadonlyMembers
    {
        public double A { get; }
        public double B { get; }
        public double C { get; }

        public ReadonlyMembers(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        // readonly (!)
        public readonly double D => B * B - 4 * A * C;

        // readonly (!)
        public readonly (double X1, double X2) Roots()
        {
            if (D < 0) throw new ArgumentException("D < 0");

            var x1 = (-B + Math.Sqrt(D)) / (2 * A);
            var x2 = (-B - Math.Sqrt(D)) / (2 * A);

            return (x1, x2);
        }
    }
}
