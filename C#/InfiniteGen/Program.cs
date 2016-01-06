using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace InfiniteGen
{
    class Program
    {
        static IEnumerable<int> GetNumber()
        {
            // Infinite generator
            int count = 0;
            while (true)
            {
                yield return count;
                count++;
            }
        }

        static void Main(string[] args)
        {
            // Infinite loop (!)
            //var items = GetNumber();

            // items = [1000..1100]
            var items = GetNumber().Skip(1000).Take(101);
            foreach (var i in items)
                WriteLine(i);
            ReadLine();
        }
    }
}
