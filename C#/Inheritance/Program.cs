using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class A
    {
        public static int SI = 42;
    }

    class B : A
    {
    }

    class AA
    {
        public const int CI = 43;
    }

    class BB : AA
    {

    }

    static class StaticA
    {

    }

    // cannot inherit from static class
    // NOTE: in IL static class is created like abstract and sealed (stackoverflow.com/questions/774181)
    //class StaticB : StaticA
    //{

    //}

    class Program
    {
        static void Main(string[] args)
        {
            // B inherit static fields
            Console.WriteLine(B.SI);
            // BB inherit const fields
            Console.WriteLine(BB.CI);

            // can change static field - obviously
            B.SI *= 2;
            // cannot (!) change const fields -> syntax error
            //BB.CI *= 2;

            B b = new B();
            // cannot (!) access static fields through instance
            //b.SI

            // as well as to const fields
            BB bb = new BB();
            //bb.CI

            Console.ReadLine();
        }
    }
}
