using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.src.ex2
{
    class Subject
    {
        private ICollection<Observer> Observers = new HashSet<Observer>();

        public void Register(Observer o)
        {
            Observers.Add(o);
        }

        public void Notify(Subject s, string action)
        {
            foreach (var o in Observers)
                o.Notify(s, action);
        }
    }
}