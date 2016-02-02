using SmartEnum.src.dp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace SmartEnum
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine($"{Shape.Circle.Name}.ToString():");
            WriteLine($"  {Shape.Circle.ToString()}");

            // Comparison between values works out of the box as well. Circles are equal to Circles, but not to Rectangles.
            WriteLine(Shape.Circle == Shape.Rectangle);
            WriteLine(Shape.Circle == Shape.Circle);

            foreach (var s in Shape.GetAllShapes())
                WriteLine(s.Name);


            ReadLine();
        }
    }
}
