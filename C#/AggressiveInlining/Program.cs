using System;
using System.Runtime.CompilerServices;

namespace AggressiveInlining
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                new C().M();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            try
            {
                new C().N();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.ReadLine();
        }
    }

    class C
    {
        public void M()
        {
            new D().M();
        }

        public void N()
        {
            new D().N();
        }
    }

    class D
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void M()
        {
            throw new ApplicationException("D.M");
        }

        public void N()
        {
            throw new ApplicationException("E.M");
        }
    }
}
