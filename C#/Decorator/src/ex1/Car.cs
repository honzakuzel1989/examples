using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.src.ex1
{
    // Decorated class
    class Car : CarInterface
    {
        public string MakeCar()
        {
            return "Car";
        }
    }
}
