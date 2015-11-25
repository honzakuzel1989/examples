using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace _2000ThinksAboutCSharp
{
    //Program
    class Program
    {
        static void Main(string[] args)
        {
            _2000Thinks ttt = new _2000Thinks();

            ttt._144();
            ttt._145();
            ttt._149();

            Console.ReadLine();
        }
    }

    //All interested things
    public class _2000Thinks
    {
        [Serializable]
        private class Person : ISerializable
        {
            public string fn, ln;
            public int age;

            public Person() { }

            //This constructor is called in deserialization
            protected Person(SerializationInfo info, StreamingContext context)
            {
                fn = (string)info.GetValue("fn", typeof(string));
                ln = (string)info.GetValue("ln", typeof(string));
                age = (int)info.GetValue("age", typeof(int));
            }

            #region ISerializable Members

            //This method is called in serialization
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("fn", fn, fn.GetType());
                info.AddValue("ln", ln, ln.GetType());
                info.AddValue("age", age, age.GetType());
            }

            #endregion
        }

        public void _144()
        {
            Person alice = new Person() { fn = "alice", ln = "palice", age = 99 };
            Person aliceClon = DeepCopy<Person>(alice);
        }

        private T DeepCopy<T>(T obj) where T : ISerializable
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, obj);
                ms.Position = 0;

                return (T)bf.Deserialize(ms);
            }
        }

        public void _145()
        {
            Person[] persons = new Person[]
            { 
                new Person(){fn="Susane", ln="B", age=26},
                new Person(){fn="George", ln="K", age=24}
            };

            Person fp = Array.Find<Person>(persons, (p) =>
                {
                    return p.fn == "George" && p.ln == "K";
                });
        }

        public void _149()
        {
            //1+2+3+4+......+9+10
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int result = numbers.Aggregate<int>((Func<int, int, int>)myFunc);
        }

        public int myFunc(int a, int b)
        {
            return a + b;
        }
    }
}
