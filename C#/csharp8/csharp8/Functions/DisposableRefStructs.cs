using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace csharp8.Functions
{
    ref struct DisposableRefStructs
    {
        public void Dispose()
        {
            Console.WriteLine("Dispose struct DisposableRefStructs by convention");
        }
    }
}
