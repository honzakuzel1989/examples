using System;
using System.Threading.Tasks;

namespace DiscardAsyncResult
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = DoSomethingAsync();
            Console.ReadLine();
        }

        static async Task DoSomethingAsync()
        {
            Console.WriteLine("DoSomethingAsync()");
            await Task.CompletedTask;
        }
    }
}
