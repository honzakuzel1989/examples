using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugAndTrace
{
    class Program
    {
        static void Main(string[] args)
        {
            // effective only if DEBUG flag is defined
            // defined in Debug configuration (by default)
            Console.WriteLine("Debug.WriteLine:");
            Debug.WriteLine(nameof(Main));

            // effective only if TRACE flag is defined
            // defined in Debug and Release configuration (by default)
            Console.WriteLine("Trace.WriteLine:");
            Trace.WriteLine(nameof(Main));

            Console.ReadLine();
        }
    }
}
