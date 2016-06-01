using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.src.ex1
{
    abstract class Visitor
    {
        public virtual void Visit(Triangle t) { throw new NotImplementedException(); }
        public virtual void Visit(Rectangle t) { throw new NotImplementedException(); }
        public virtual void Visit(Circle t) { throw new NotImplementedException(); }
    }
}
