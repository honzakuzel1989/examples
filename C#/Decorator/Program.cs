using System;
using Decorator.src.ex1;
using Decorator.src.ex2;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            new CarClient();
            new FormatterClient();
            Console.ReadLine();
        }
    }
}
