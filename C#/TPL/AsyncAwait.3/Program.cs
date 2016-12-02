using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait._3
{
    class Program
    {
        static void Main(string[] args)
        {
            //AsyncVoidExceptions_CannotBeCaughtByCatch();
            AsyncVoidExceptions_CanBeCaughtByCatch();

            Console.ReadLine();
        }

        private static async void AsyncVoidExceptions_CanBeCaughtByCatch()
        {
            try
            {
                await ThrowExceptionAsyncTask();
            }
            catch (Exception)
            {
                // The exception is caught here!!
                Console.WriteLine("shown");
            }
        }

        private static async Task ThrowExceptionAsyncTask()
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        private static async void ThrowExceptionAsync()
        {
            // Fast-path, same as Task.Delay(0) in lower versions of .NET
            await Task.CompletedTask;
            throw new InvalidOperationException();
        }

        public static void AsyncVoidExceptions_CannotBeCaughtByCatch()
        {
            try
            {
                ThrowExceptionAsync();
            }
            catch (Exception)
            {
                // The exception is never caught here!!
                Console.WriteLine("Never shown");
            }
        }
    }
}
