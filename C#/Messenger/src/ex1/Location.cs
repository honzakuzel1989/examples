using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.src.ex1
{
    // Messenger (!)
    class Coordinates
    {
        // READONLY (!)
        public readonly double Lat;
        public readonly double Lon;
        public readonly double Alt;
        // or
        //public double Lat { get; }
        // ...


        public Coordinates(double lat, double lon, double alt)
        {
            // Set only once - immutable
            Lat = lat;
            Lon = lon;
            Alt = alt;
        }
    }
}
