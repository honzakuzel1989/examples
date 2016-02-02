using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.src
{
    class DecoratedClass : DecoratorInterface
    {
        public void Operation()
        {
            Console.WriteLine(GetType().Name + " - " + MethodBase.GetCurrentMethod().Name);
        }
    }
}
