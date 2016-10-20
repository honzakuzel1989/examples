using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryVsLogicalComparison
{
    class Program
    {
        class Foo
        {
            public int X { get; }
        }

        static void Main(string[] args)
        {
            bool methodIsReady = false;

            // Ok
            if (methodIsReady && method())
                ; // do something
            else
                Console.WriteLine($"flag={methodIsReady}");

            try
            {
                // Throw exception
                if (methodIsReady & method())
                    ; // do something
            }
            catch
            {
                Console.WriteLine($"exception");
            }

            // --
            Console.ReadLine();

            // Or
            Foo foo = null;
            bool fooIsReady = false;

            // Ok
            if (fooIsReady && foo.X > 5)
                ; // do something
            else
                Console.WriteLine($"fooIsReady={fooIsReady}");

            try
            {
                // Throw null reference exception
                if (fooIsReady & foo.X > 5)
                    ; // do something
            }
            catch
            {
                Console.WriteLine($"null reference exception");
            }

            // --
            Console.ReadLine();
        }

        static bool method()
        {
            throw new Exception();
        }
    }
}
