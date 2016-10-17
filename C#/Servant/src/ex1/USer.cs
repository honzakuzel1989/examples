using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servant.src.ex1
{
    class User
    {
        public User()
        {
            IServiced a = new A();
            IServiced b = new B();
            IServiced c = new C();

            Servant s = new Servant();
            s.Action(a);
            s.Action(b);
            s.Action(c);
        }
    }
}
