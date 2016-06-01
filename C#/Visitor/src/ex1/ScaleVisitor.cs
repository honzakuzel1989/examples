using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.src.ex1
{
    class ScaleVisitor : Visitor
    {
        public override void Visit(Circle t)
        {
            t.Scale = 2;
        }

        public override void Visit(Rectangle t)
        {
            t.Scale = 5;
        }

        public override void Visit(Triangle t)
        {
            t.Scale = 3;
        }
    }
}
