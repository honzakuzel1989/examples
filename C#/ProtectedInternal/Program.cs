using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Source: stackoverflow.com/questions/585859
// msdn.microsoft.com/cs-cz/library/wxh6fsc7.aspx
// protected internal: Access is limited to the current assembly OR types derived from the containing class.

namespace ProtectedInternal
{
    class Program
    {
        static void Main(string[] args)
        {
            C c = new C();
            //not accessible
            //c.X

            D d = new D();
            //not accessible
            //d.X

            //accsessible using wrapper
            Console.WriteLine(d.XX());

            Console.ReadLine();
        }
    }

    class D : C
    {
        public D() : base()
        {

        }

        public int XX()
        {
            return X;
        }
    }
}
