using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.src.ex2.props
{
    // Decorator class
    class CRC : FormatterInterface
    {
        FormatterInterface fi;

        public CRC(FormatterInterface fi)
        {
            this.fi = fi;
        }

        public string Format(string data)
        {
            return fi.Format(data) + "<CRC>";
        }
    }
}
