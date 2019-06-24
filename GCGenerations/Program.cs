using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCGenerations
{
    class Program
    {
        static void Main(string[] args)
        {
            const int loh = 21247;

            int x = 1;
            int[] y = new int[loh];
            int[] z = new int[loh - 1];

            Console.WriteLine(GC.GetGeneration(x));
            Console.WriteLine(GC.GetGeneration(y));
            Console.WriteLine(GC.GetGeneration(z));

            Console.ReadLine();
        }
    }
}
