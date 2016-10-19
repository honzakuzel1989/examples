using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.src.ex1
{
    abstract class Subject
    {
        private ICollection<Observer> Observers = new HashSet<Observer>();

        public void Register(Observer o)
        {
            Observers.Add(o);
        }

        public void Unregister(Observer o)
        {
            Observers.Remove(o);
        }

        public void Notify()
        {
            foreach (var o in Observers)
                o.Notify();
        }
    }
}
