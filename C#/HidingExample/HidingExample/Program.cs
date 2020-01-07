using System;

namespace HidingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new A();
            var b = new B();
            var c = new C();

            Console.WriteLine(a.pFoo);
            Console.WriteLine(a.mFoo());

            Console.WriteLine(b.pFoo);
            Console.WriteLine(b.mFoo());

            Console.WriteLine(c.pFoo);
            Console.WriteLine(c.mFoo());

            Console.WriteLine();

            var ia = (IC)a;
            var ib = (IC)b;
            var ic = (IC)c;

            Console.WriteLine(ia.pFoo);
            Console.WriteLine(ia.mFoo());

            // Call pFoo and mFoo from A
            Console.WriteLine(ib.pFoo);
            Console.WriteLine(ib.mFoo());

            // Call pFoo and mFoo from C
            Console.WriteLine(ic.pFoo);
            Console.WriteLine(ic.mFoo());

            Console.ReadLine();
        }
    }

    interface IC
    {
        string pFoo { get; }
        string mFoo();
    }

    class A : IC
    {
        public string pFoo => "A::pFoo";
        public string mFoo() => "A::mFoo";
    }

    class B : A
    {
        // Hiding mFoo and pFoo
        public new string pFoo => "B::pFoo";
        public new string mFoo() => "B::mFoo";
    }

    class C : A, IC
    {
        // Hiding mFoo and pFoo and implement IC
        public new string pFoo => "C::pFoo";
        public new string mFoo() => "C::mFoo";
    }
}
