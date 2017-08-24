using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumeratedType
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DayOfWeek.MONDAY);
            Console.WriteLine(DayOfWeek.MONDAY.Order);
            Console.WriteLine();
            Console.WriteLine(DayOfWeek.DaysByName().ToReadable());
            Console.WriteLine();
            Console.WriteLine(DayOfWeek.DaysOrder().ToReadable());

            Console.ReadLine();
        }
    }
}
