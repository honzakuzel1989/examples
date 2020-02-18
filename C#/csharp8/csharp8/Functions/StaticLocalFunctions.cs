using System;
using System.Collections.Generic;
using System.Text;

namespace csharp8.Functions
{
    static class StaticLocalFunctions
    {
        public static uint FibNum(uint num)
        {
            // Static local function - slightly faster than classic local function
            static uint Add(uint f, uint s)
            {
                return checked(f + s);
            }

            // Positions initializer
            (uint f, uint s) = (0, 1);
            for (int i = 1; i < num; i++)
            {
                (f, s) = (s, Add(f, s));
            }

            return num > 0 ? s : f;
        }

        public static IEnumerable<uint> FibSeq(uint count)
        {
            for (uint i = 0; i < count; i++)
            {
                yield return FibNum(i);
            }
        }
    }
}
