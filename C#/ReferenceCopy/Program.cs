using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReferenceCopy
{
    class Program
    {
        class Foo
        {
            public object Baz { get; set; }
            public int Bar { get; set; }
        }

        static void Main(string[] args)
        {
            Foo f = new Foo();
            f.Bar = 10;
            f.Baz = new Nullable<double>(6.0);

            Foo b = f;
            f = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();

            int bar = b.Bar;
        }
    }
}
