using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedClass
{
    class A
    {
        class B
        {
            public B()
            {

            }
        }
    }

    class C
    {
        public class D
        {
            internal class E
            {
                public E()
                {

                }
            }

            public D()
            {

            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            // A.B is private - not accessible

            C c = new C();
            // (!) not permitted
            //c.D

            // C.D is pubic - accessible
            C.D d = new C.D();

            // C.D.E is internal - accessible
            C.D.E e = new C.D.E();
        }
    }
}
