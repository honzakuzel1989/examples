using System;
using System.Collections.Generic;
using System.Text;

namespace csharp8.Functions
{
    class InterpolatedVerbatimStrings
    {
        void Print()
        {
            // Optional characters's order
            Console.WriteLine($@"... {42}");
            Console.WriteLine(@$"... {42}");
        }
    }
}
