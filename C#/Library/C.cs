using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class C
    {
        // (!!) accessible in inherited classes and in this library
        protected internal int X => 42;

        public C()
        {

        }
    }
}
