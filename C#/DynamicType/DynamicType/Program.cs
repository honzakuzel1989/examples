using System;

namespace DynamicType
{
    //
    // The example is based on https://www.codeproject.com/Articles/121568/Dynamic-Type-Using-Reflection-Emit and 
    // converted as simple as it possible to .NET core.
    //

    static class Program
    {
        static void Main(string[] args)
        {
            var tg = new TypeGenerator();
            tg.CreateSumMethodInsideMyMath();

            Console.ReadLine();
        }
    }
}
