using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.src
{
    class Decorator : DecoratorInterface
    {
        DecoratorInterface decorator;

        public Decorator(DecoratorInterface d)
        {
            decorator = d;
        }

        public void Operation()
        {
            Console.WriteLine(GetType().Name + " - " + MethodBase.GetCurrentMethod().Name);
            decorator.Operation();
        }
    }
}
