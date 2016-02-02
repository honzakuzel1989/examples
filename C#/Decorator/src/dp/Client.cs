using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.src
{
    class Client
    {
        public Client()
        {
            new Decorator(new DecoratedClass()).Operation();
        }
    }
}
