using Servant.src.ex1;
using Servant.src.ex3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servant
{
    class Program
    {
        static void Main(string[] args)
        {
            //User client = new User();

            Plane plane = new Plane();
            Car car = new Car();
            Pedestrian pedestrian = new Pedestrian();

            plane.Move(1500);
            car.Move(1500);
        }
    }
}
