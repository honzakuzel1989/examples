using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait.Exception
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
            Console.ReadLine();
        }

        static async Task MainAsync()
        {
            Task t = ThrowExceptionAsync();
            try
            {
                // the exception is raised when the task is awaited
                await t;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static async Task ThrowExceptionAsync()
        {
            await Task.Delay(1000);
            throw new InvalidOperationException();
        }
    }
}
