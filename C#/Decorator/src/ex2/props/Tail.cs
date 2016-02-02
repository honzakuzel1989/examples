using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.src.ex2.props
{
    // Decorator class
    class Tail : FormatterInterface
    {
        FormatterInterface fi;

        public Tail(FormatterInterface fi)
        {
            this.fi = fi;
        }

        public string Format(string data)
        {
            return fi.Format(data) + "<Tail>";
        }
    }
}
