using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.src.ex2.props
{
    // Decorator class
    class Head : FormatterInterface
    {
        FormatterInterface fi;

        public Head(FormatterInterface fi)
        {
            this.fi = fi;
        }

        public string Format(string data)
        {
            return "<Head>" + fi.Format(data);
        }
    }
}
