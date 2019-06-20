using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VF.Calculator
{
    internal class InverseOperationProvider : IOperationProvider
    {
        public int Add(int a, int b) => -(a + b);
        public int Sub(int a, int b) => -(a - b);
        public int Mul(int a, int b) => -(a * b);
        public int Div(int a, int b) => -(a / b);
    }

    internal class StandardOperationProvider : IOperationProvider
    {
        public int Add(int a, int b) => a + b;
        public int Sub(int a, int b) => a - b;
        public int Mul(int a, int b) => a * b;
        public int Div(int a, int b) => a / b;
    }

    public interface IOperationProvider
    {
        int Add(int a, int b);
        int Sub(int a, int b);
        int Mul(int a, int b);
        int Div(int a, int b);
    }
}
