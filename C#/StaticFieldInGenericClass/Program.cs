using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticFieldInGenericClass
{
    class Program
    {
        static void Main(string[] args)
        {
            C<int> ci = new C<int>(10);
            C<double> cd = new C<double>(100.0);
            C<float> cf = new C<float>(42f);
            C<char> cc = new C<char>('x');

            Console.WriteLine(ci);
            Console.WriteLine(cd);
            Console.WriteLine(cf);
            Console.WriteLine(cc);

            Console.ReadLine();
        }
    }

    class C<T> where T : struct
    {
        // static field is shared between all instances of one type - C<int> is different type like C<float>, for example
        static T STATIC_ITEM = default(T);

        public C(T value)
        {
            STATIC_ITEM = value;
        }

        public override string ToString()
        {
            return STATIC_ITEM.ToString();
        }
    }
}
