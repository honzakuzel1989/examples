using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposeCall
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputContent = string.Empty;

            // WRONG WAY

            //using (DisposableClass dc = new DisposableClass())
            //{
            //    // Object Disposed Exception (!)
            //    inputContent = dc.GetDisposedCustomStream().ReadToEnd();
            //}

            // GOOD WAY

            using (DisposableClass dc = new DisposableClass())
            {
                using (CustomStreamReader cr = dc.GetCustomStream())
                {
                    inputContent = cr.ReadToEnd();
                }
            }

            Console.WriteLine(inputContent);
            Console.ReadLine();
        }
    }

    class DisposableClass : IDisposable
    {
        public DisposableClass()
        {
            Console.WriteLine("Create DisposableClass");
        }

        public CustomStreamReader GetDisposedCustomStream()
        {
            using (CustomStreamReader sr = new CustomStreamReader("Input.txt"))
            {
                return sr;
            }   // Dispose (!)
        }

        public CustomStreamReader GetCustomStream()
        {
            CustomStreamReader sr = new CustomStreamReader("Input.txt");
            {
                return sr;
            }
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose DisposableClass");
        }
    }
}
