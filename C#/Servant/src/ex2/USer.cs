using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servant.src.ex2
{
    class User
    {
        public User()
        {
            IServiced a = new A();
            IServiced b = new B();
            IServiced c = new C();

            a.DoAction();
            b.DoAction();
            c.DoAction();
        }
    }
}
