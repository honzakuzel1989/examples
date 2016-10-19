using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.src.ex2
{
    class Radio : Observer
    {
        public Radio(Subject s) : base(s)
        {
        }

        public override void Notify(Subject s, string masg)
        {
            Console.Beep();
        }
    }
}
