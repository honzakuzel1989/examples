using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.src.ex1;

namespace Visitor
{
    class Program
    {
        static ICollection<Geometry> Geometries = new Geometry[]
            {
                new Rectangle(),
                new Circle(),
                new Circle(),
                new Rectangle(),
                new Rectangle(),
                new Triangle(),
                new Triangle(),
                new Triangle(),
                new Circle(),
            };

        static void Main(string[] args)
        {
            Visitor.src.ex1.Visitor colorize = new ColorizeVisitor();
            Visitor.src.ex1.Visitor scale = new ScaleVisitor();

            foreach (var g in Geometries)
            {
                g.Accept(colorize);
                g.Accept(scale);
            }

            foreach (var g in Geometries)
                Console.WriteLine(g);
        }
    }
}
