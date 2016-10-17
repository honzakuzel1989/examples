using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Servant.src.ex3
{
    class MoveServant
    {
        public void Move(IMove serviced, uint distance)
        {
            Console.WriteLine($"Start:{serviced}:{serviced.Distance}+{distance}");

            uint finalDistance = serviced.Distance + distance;
            while (serviced.Distance < finalDistance)
            {
                // one hour :D
                Thread.Sleep(1000);
                serviced.Distance += serviced.Speed;

                Console.WriteLine($"Moving:{serviced.Distance}");
            }

            Console.WriteLine($"Done...");
        }
    }
}
