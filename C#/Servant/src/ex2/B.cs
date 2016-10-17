using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servant.src.ex2
{
    class B : IServiced
    {
        Servant servant = new Servant();

        public void DoAction()
        {
            servant.Action(this);
        }
    }
}
