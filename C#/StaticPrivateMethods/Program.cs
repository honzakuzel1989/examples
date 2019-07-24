using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace StaticPrivateMethods
{
    [Serializable]
    class AS
    {
        private void Add(int value)
        {

        }
    }

    [Serializable]
    class BS
    {
        private void Add(int value)
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var ss = Enumerable.Repeat(new AS(), 1000).ToArray();
            var staticss = Enumerable.Repeat(new BS(), 1000).ToArray();

            Console.WriteLine(GetObjectSize(new AS()));
            Console.WriteLine(GetObjectSize(new BS()));

            Console.ReadLine();
        }

        private static int GetObjectSize(object TestObject)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            byte[] Array;
            bf.Serialize(ms, TestObject);
            Array = ms.ToArray();
            return Array.Length;
        }
    }
}
