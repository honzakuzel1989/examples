using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.src.ex1
{
    abstract class Geometry
    {
        public string Color { get; set; }
        public int Scale { get; set; }

        public abstract void Accept(Visitor v);

        public override string ToString()
        {
            return $"{GetType().Name}: {nameof(Color)}={Color}, {nameof(Scale)}={Scale}";
        }
    }
}
