using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SizeOfEmptyObjects
{
    [Serializable]
    class C
    {
    }

    struct S
    {
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 131B
            Console.WriteLine(GetSize(new C()));
            // 28B
            Console.WriteLine(GetSize(new int[] { }));
            // 1B
            Console.WriteLine(Marshal.SizeOf(new S()));

            Console.ReadLine();
        }

        static long GetSize(object o)
        {
            long size = 0;
            using (Stream s = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(s, o);
                size = s.Length;
            }
            return size;
        }
    }
}
