using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VF.Calculator
{
    public class InverseCalculator : Calculator
    {
        public InverseCalculator() : base(new InverseOperationProvider())
        {
        }
    }

    public class StandardCalculator : Calculator
    {
        public StandardCalculator() : base(new StandardOperationProvider())
        {
        }
    }

    public abstract class Calculator : ICalculator
    {
        public string Name => GetType().Name;

        private readonly IOperationProvider operationProvider;

        public Calculator(IOperationProvider operationProvider)
        {
            this.operationProvider = operationProvider;
        }

        public int Add(int a, int b) => operationProvider.Add(a, b);

        public int Sub(int a, int b) => operationProvider.Sub(a, b);

        public int Mul(int a, int b) => operationProvider.Mul(a, b);

        public int Div(int a, int b) => operationProvider.Div(a, b);
    }

    public interface ICalculator
    {
        string Name { get; }

        int Add(int a, int b);

        int Sub(int a, int b);

        int Mul(int a, int b);

        int Div(int a, int b);
    }
}
