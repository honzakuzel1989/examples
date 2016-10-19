using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.src.ex2
{
    class Table : Observer
    {
        public Table(Subject s) : base(s)
        {
        }

        public override void Notify(Subject s, string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
