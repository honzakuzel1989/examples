using Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    // Text file
    abstract class Composite<T> : IComponent<T>
    {
        private List<IComponent<T>> components = new List<IComponent<T>>();

        public void Display()
        {
            components.ForEach(c => c.Display());
        }

        public void Add(IComponent<T> component)
        {
            components.Add(component);
        }

        public void Remove(IComponent<T> component)
        {
            components.Remove(component);
        }
    }
}
