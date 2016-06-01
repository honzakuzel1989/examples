using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.src.ex1
{
    class ColorizeVisitor : Visitor
    {
        public override void Visit(Circle t)
        {
            t.Color = "Reg";
        }

        public override void Visit(Rectangle t)
        {
            t.Color = "Green";
        }

        public override void Visit(Triangle t)
        {
            t.Color = "Blue";
        }
    }
}
