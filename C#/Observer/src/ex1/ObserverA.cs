using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.src.ex1
{
    class ObserverA : Observer
    {
        public ObserverA(Subject s) : base(s)
        {

        }

        public override void Notify()
        {
            Console.WriteLine($"{this}.{nameof(Notify)}");
        }
    }
}
