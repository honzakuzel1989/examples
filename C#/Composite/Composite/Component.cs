using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    // Text line
    abstract class Component<T> : IComponent<T>
    {
        public T Item { get; set; }

        public void Display()
        {
            Console.WriteLine(Item);
        }
    }
}
