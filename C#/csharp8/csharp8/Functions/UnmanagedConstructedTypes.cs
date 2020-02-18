using System;
using System.Collections.Generic;
using System.Text;

namespace csharp8.Functions
{
    public struct Coords<T>
    {
        public T Lat;
        public T Long;
        public T Alt;
    }

    class UnmanagedConstructedTypes
    {
        public static void DisplaySize()
        {
            DisplaySize<Coords<int>>();
            DisplaySize<Coords<double>>();
        }

        private unsafe static void DisplaySize<T>() where T : unmanaged
        {
            Console.WriteLine($"{typeof(T)} is unmanaged and its size is {sizeof(T)} bytes");
        }
    }
}
