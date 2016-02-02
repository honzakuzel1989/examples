using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.src.ex1.props
{
    // Decorator class
    class _4x4 : CarInterface
    {
        CarInterface ci;

        public _4x4(CarInterface ci)
        {
            this.ci = ci;
        }

        public string MakeCar()
        {
            return ci.MakeCar() + "\n 4x4";
        }
    }
}
