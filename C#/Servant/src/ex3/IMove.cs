using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servant.src.ex3
{
    interface IMove
    {
        //MoveServant MoveServant { get; }

        uint Speed { get; }
        uint Distance { get; set; }
        void Move(uint distance);
    }
}
