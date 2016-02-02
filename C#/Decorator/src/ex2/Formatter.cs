using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.src.ex2.props
{
    // Decorated class
    class Formatter : FormatterInterface
    {
        public string Format(string data)
        {
            return "<" + data + ">";
        }
    }
}
