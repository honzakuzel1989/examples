using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    interface IComposite<T> :  IComponent<T>
    {
        void Add(IComponent<T> component);
        void Remove(IComponent<T> component);
    }
}
