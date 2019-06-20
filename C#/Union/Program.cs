using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Union
{
    [StructLayout(LayoutKind.Explicit, Pack = 2)]
    struct Union
    {
        [FieldOffset(0)]
        public int i;
        [FieldOffset(0)]
        public short s;
        [FieldOffset(0)]
        public byte b;
        [FieldOffset(4)]
        public char c;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Marshal.SizeOf<Union>());

            var u1 = new Union { s = 255, c = 's' };
            Console.WriteLine($"{u1.c}, {u1.i}, {u1.s}, {u1.b}");
            var u2 = new Union { i = int.MaxValue, c = 'i' };
            Console.WriteLine($"{u2.c}, {u2.i}, {u2.s}, {u2.b}");

            Console.WriteLine((byte)u2.i);
            Console.WriteLine((short)u2.i);
            Console.WriteLine((int)u2.i);

            Console.ReadLine();
        }
    }
}
