using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.src.ex1
{
    class Rectangle : Geometry
    {
        public override void Accept(Visitor v)
        {
            v.Visit(this);
        }
    }
}
