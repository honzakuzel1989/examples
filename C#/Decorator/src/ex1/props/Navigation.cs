using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.src.ex1.props
{
    // Decorator class
    class Navigation : CarInterface
    {
        CarInterface ci;

        public Navigation(CarInterface ci)
        {
            this.ci = ci;
        }

        public string MakeCar()
        {
            return ci.MakeCar() + "\n Navigation";
        }
    }
}
