using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VF.Calculator
{
    public class DecadicResultFormatter : ResultFormatter
    {
        public override string Format(int x)
        {
            return "0d" + Convert.ToString(x, 10);
        }
    }

    public class HexadeciamResultFormatter : ResultFormatter
    {
        public override string Format(int x)
        {
            return "0x" + Convert.ToString(x, 16);
        }
    }

    public class BinaryResultFormatter : ResultFormatter
    {
        public override string Format(int x)
        {
            return "0b" + Convert.ToString(x, 2);
        }
    }

    public abstract class ResultFormatter : IResultFormatter
    {
        public string Name => GetType().Name;

        public abstract string Format(int x);
    }

    public interface IResultFormatter
    {
        string Name { get; }
        string Format(int x);
    }
}
