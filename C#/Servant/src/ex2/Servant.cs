using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servant.src.ex2
{
    class Servant
    {
        public void Action(IServiced serviced)
        {
            serviced.DoAction();
        }
    }
}
