using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadStaticAttrib
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "main";

            Cls c1 = new Cls();
            c1.D = 10;

            Cls c2 = new Cls();
            c2.D = 20;

            // ThreadStatic attribute is ignored for instance variables
            Console.WriteLine($"c1.D = {c1.D}\nc2.D = {c2.D}");

            // Static variable
            Cls.B = 10;
            // ThreadStatic variable
            Cls.C = 10;

            Thread t = new Thread(new ThreadStart(() =>
            {
                Cls.B = 20;
                // In t thread C is 20
                Cls.C = 20;

                Console.WriteLine($"{Thread.CurrentThread.Name}:\nCls.B = {Cls.B}\nCls.C = {Cls.C}");
            }));

            t.Name = "t";
            t.Start();
            t.Join();

            // In main thread C is 10 but B is 20
            Console.WriteLine($"{Thread.CurrentThread.Name}:\nCls.B = {Cls.B}\nCls.C = {Cls.C}");
            Console.ReadLine();
        }
    }

    class Cls
    {
        public static int B;
        [ThreadStatic]
        public static int C;
        [ThreadStatic]
        public int D;
    }
}
