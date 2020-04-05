using System;
using System.Runtime.InteropServices;

namespace PinnedObject
{
    static class Program
    {
        static void Main(string[] args)
        {
            const int len = 65536;

            byte[] buffer = new byte[len];
            new Random().NextBytes(buffer);

            GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            IntPtr ptr = handle.AddrOfPinnedObject();

            Console.WriteLine(GetMin(ptr, len));
            Console.ReadLine();
        }

        unsafe static (byte min, byte max) GetMin(IntPtr ptr, int len)
        {
            byte max = byte.MinValue;
            byte min = byte.MaxValue;

            byte* arr = (byte*)ptr.ToPointer();
            for (int i = 0; i < len; i++)
            {
                byte item = arr[i];
                if (item > max) max = item;
                if (item < min) min = item;
            }
                
            return (min, max);
        }
    }
}
