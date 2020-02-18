using System;
using System.Drawing;
using System.Threading;

namespace GenericConstraints
{
    class Program
    {
        delegate void PrintState(bool state);

        static void Main(string[] args)
        {
            Console.WriteLine(new EnumConstraint<ApartmentState>(ApartmentState.Unknown));
            Console.WriteLine();

            Console.WriteLine(new DelegateConstraint<PrintState>(b => Console.WriteLine(b)));
            Console.WriteLine();

            Console.WriteLine(new UnmanagedConstraint<int>(new[] { 1, 2, 3, 4, 5 }));
            Console.WriteLine();

            Console.ReadLine();
        }
    }

    class EnumConstraint<T> where T : Enum
    {
        public EnumConstraint(T defVal)
        {
            foreach (var item in Enum.GetValues(typeof(T)))
                Console.WriteLine(item);

            Console.WriteLine(defVal);
        }
    }

    class DelegateConstraint<T> where T : Delegate
    {
        public DelegateConstraint(T data)
        {
            Console.WriteLine(data.Target);
            Console.WriteLine(data.Method.Name);

            data.Method.Invoke(data.Target, new object[] { true });
        }
    }

    class UnmanagedConstraint<T> where T : unmanaged
    {
        public UnmanagedConstraint(T[] data)
        {
            ReadOnlySpan<T> GetData() => new ReadOnlySpan<T>(data);

            foreach (var item in GetData())
                Console.WriteLine(item);
        }
    }
}
