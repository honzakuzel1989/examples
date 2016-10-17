using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servant.src.ex3
{
    class Boat : IMove
    {
        /*public*/
        MoveServant MoveServant { get; } = new MoveServant();

        public uint Distance { get; set; }

        // in kilometers per hour
        public uint Speed => 75;

        public void Move(uint distance)
        {
            MoveServant.Move(this, distance);
        }
    }
}
