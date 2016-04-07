using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

/*
 * Black magic (!)
 * stackoverflow.com/questions/6960910
 * stackoverflow.com/questions/3271223
 */

namespace CoClass
{
    class Program
    {
        [ComImport]
        [Guid("673F4871-EA22-42E0-9153-2D76C7C6002C")]
        [CoClass(typeof(Foo))]
        interface IFoo
        {
            void SayHello();
            void SaySomething();
        }

        class Foo : IFoo
        {
            string something = string.Empty;

            public Foo()
            {
                WriteLine(nameof(Foo));
            }

            public Foo(string what) : this()
            {
                something = what;
            }

            public void SayHello()
            {
                WriteLine("Hello");
            }

            public void SaySomething()
            {
                WriteLine(something);
            }
        }

        [ComImport]
        [Guid("BB204EBA-BFA2-48C9-942B-BAB753A5B9A9")]
        [CoClass(typeof(Baz))]
        interface IBar
        {
            void SayName();
        }

        abstract class Bar : IBar
        {
            public abstract void SayName();
        }

        class Baz : Bar
        {
            public override void SayName()
            {
                WriteLine(nameof(Baz));
            }
        }

        static void Main(string[] args)
        {
            IFoo f = new IFoo();
            f.SayHello();

            IFoo ff = new IFoo("Something");
            ff.SaySomething();

            IBar b = new IBar();
            b.SayName();

            Console.ReadLine();
        }
    }
}
