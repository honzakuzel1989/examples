using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.src.ex2
{
    class Player
    {
        public string FullName { get; private set; }

        public Player(string fullName)
        {
            FullName = fullName;
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}
