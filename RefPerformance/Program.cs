using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RefPerformance
{
    class Program
    {
        const uint CNT = 100_000_000;

        // 32B struct
        struct S
        {
            public double a, b, c, d;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Marshal.SizeOf<S>());

            DateTime start = DateTime.Now;
            WithoutRef();
            Console.WriteLine(DateTime.Now.Subtract(start));
            WithRef();
            Console.WriteLine(DateTime.Now.Subtract(start));
            Console.ReadLine();
        }

        private static void WithoutRef()
        {
            var s = new S();
            for (int i = 0; i < CNT; i++)
            {
                X(s);
            }
        }

        private static S X(S s)
        {
            s.a = 'a';
            s.b = 'b';
            s.c = 'c';
            s.d = 'd';

            return s;
        }

        private static void WithRef()
        {
            var s = new S();
            for (int i = 0; i < CNT; i++)
            {
                RefX(ref s);
            }
        }

        private static void RefX(ref S s)
        {
            s.a = 'a';
            s.b = 'b';
            s.c = 'c';
            s.d = 'd';
        }
    }
}
