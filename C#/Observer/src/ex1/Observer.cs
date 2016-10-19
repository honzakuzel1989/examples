using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.src.ex1
{
    abstract class Observer
    {
        public Observer(Subject s)
        {
            s.Register(this);
        }

        public abstract void Notify();
    }
}
