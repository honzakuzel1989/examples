using Messenger.src.ex1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger
{
    class Program
    {
        static void Main(string[] args)
        {
            // Messenger (!)
            Coordinates c = new Coordinates(14.2, 22.8, 0);
            Location l = new Location { Coordinates = c };
        }
    }
}
