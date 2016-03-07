using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditionNullTrap
{
    class SmartNumber
    {
        public int Y = 42;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Maybe expected n (10 in this case), but result is 0
            Console.WriteLine(Add(10, null));

            Console.ReadLine();
        }

        static int Add(int n, SmartNumber sn)
        {
            // if sn is null, result is always 0, because n + null (! int + null / numeric + null) is null and null ?? 0 is 0
            return n + sn?.Y ?? 0;
            // you have to use brackets
            //return n + (sn?.Y ?? 0);
        }
    }
}
