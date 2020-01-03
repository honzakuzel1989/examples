using System;
using System.Collections.Generic;
using System.Linq;

namespace PolygonAreaSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var polygon1 = new Polygon(new[] { (0, 0), (1, 0), (1, 1), (0, 1) });
            var polygon2 = new Polygon(new[] { (0, 0), (4, 0), (4, 2), (0, 1) });
            var polygon3 = new Polygon(new[] { (1, 1), (2, 2), (3, 1), (4, 4), (1, 3) });
            var polygon4 = new Polygon(new[] { (0, 0), (2, 0), (1, 1), (2, 2), (0, 2), (1, 1) });

            var areasolver = new AreaSolver();

            // 1
            Console.WriteLine(areasolver.Solve(polygon1));
            // 6
            Console.WriteLine(areasolver.Solve(polygon2));
            // 6
            Console.WriteLine(areasolver.Solve(polygon3));
            // 2
            Console.WriteLine(areasolver.Solve(polygon4));

            Console.ReadLine();
        }
    }

    //
    // Iface and base classes for shapes
    //

    internal interface IShape
    {
        IEnumerable<(int x, int y)> Coords { get; }
    }

    abstract class Shape : IShape
    {
        public IEnumerable<(int, int)> Coords { get; protected set; }

        public Shape(IEnumerable<(int x, int y)> coords)
        {
            Coords = coords;
        }
    }

    //
    // Shapes
    //

    class Polygon : Shape
    {
        public Polygon(IEnumerable<(int x, int y)> coords) : base(coords)
        {

        }
    }

    //
    // Solver
    //

    class AreaSolver
    {
        public double Solve(Polygon polygon)
        {
            // INFO:  Obsah mnohoúhelníka, jehož strany se nekříží, se dá spočítat Gaussovou metodou pro výpočet plochy
            // https://cs.wikipedia.org/wiki/Mnoho%C3%BAheln%C3%ADk

            // Cnt
            (int x, int y)[] coords = polygon.Coords.ToArray();
            var n = coords.Length;

            // Calculation
            var sum = 0.0;
            for (int i = 0; i < n; i++)
            {
                // Rotate
                var iplusone = i + 1 < n ? i + 1 : 0;

                // Sum
                var xy = coords[i];
                var xyplusone = coords[iplusone];

                sum += (xy.x * xyplusone.y - xyplusone.x * xy.y);
            }

            // Abs and divide
            var asum = Math.Abs(sum);
            var result = asum / 2;

            // Heureka
            return result;
        }
    }
}
