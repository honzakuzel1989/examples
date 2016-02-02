using Decorator.src.ex1.props;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.src.ex1
{
    // Decorator client
    class CarClient
    {
        public CarClient()
        {
            Console.WriteLine("-----\n|Ex1|\n-----");

            Console.WriteLine(new Car().MakeCar());
            Console.WriteLine(new _4x4(new Car()).MakeCar());
            Console.WriteLine(new AirConditioning(new _4x4(new Car())).MakeCar());
            Console.WriteLine(new AirConditioning(new HeatedSeats(new _4x4(new Car()))).MakeCar());
            Console.WriteLine(new AirConditioning(new HeatedSeats(new Car())).MakeCar());
        }
    }
}
