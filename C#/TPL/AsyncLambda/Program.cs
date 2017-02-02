using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync();
            Console.ReadLine();
        }

        static async void MainAsync()
        {
            var x = Task.Run(async () =>
            {
                await Task.Delay(5);
                return 42;
            });

            var y = await x;
            Console.WriteLine(y);
        }
    }
}
