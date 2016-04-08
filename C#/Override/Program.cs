using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Override
{
    class Program
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        static void DUMP()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            MethodBase mb = sf.GetMethod();

            WriteLine($"{mb.ReflectedType}+{mb.Name}()");
        }

        class A
        {
            public virtual void M()
            {
                DUMP();
            }

            public void N()
            {
                DUMP();
            }

            public void O()
            {
                DUMP();
            }
        }

        class B : A
        {
            // hide base.M using override
            public override void M()
            {
                DUMP();
            }

            // (!) hides base.N using new
            public new void N()
            {
                DUMP();
            }

            // (!!) hide base.N too
            public void O()
            {
                DUMP();
            }
        }

        static void Main(string[] args)
        {
            WriteLine("A a = new A();");
            A a = new A();
            a.M();
            a.N();
            a.O();

            WriteLine("B b = new B();");
            B b = new B();
            b.M();
            b.N();
            b.O();

            WriteLine("A x = new B();");
            A x = new B();
            x.M();
            x.N();
            x.O();

            WriteLine("A y = new B(); + cast (B)y");
            A y = new B();
            B z = y as B;
            z.M();
            (x as B).N();
            z.O();

            Console.ReadLine();
        }
    }
}
