using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Source: stackoverflow.com/questions/2432909

namespace DefaultKeyword
{
    class Program
    {
        private delegate int dlg(int a, int b);

        interface IFoo
        {

        }

        class Foo
        {

        }

        struct S { }

        enum E { }
        enum F : int { }

        static void W(object o)
        {
            Console.WriteLine(o == null ? "null" : o);
        }

        static void Main(string[] args)
        {
            // For a value - type other than Nullable<T> it returns a zero - initialized value
            W(default(int));
            W(default(double));
            W(default(DateTime));
            W(default(S));
            W(default(E));

            // Newline
            W(string.Empty);

            // For a reference - type, it returns null
            W(default(int[]));
            W(default(string));
            W(default(Foo));
            W(default(dlg));
            // (!) interface
            W(default(IFoo));
            W(default(object));

            // Newline
            W(string.Empty);

            // For Nullable<T> it returns the empty (pseudo-null the same as null) value that
            W(default(Nullable<DateTime>));
            W(default(Nullable<int>));

            Console.ReadLine();
        }
    }
}
