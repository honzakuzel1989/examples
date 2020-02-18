using System;

namespace Eratosthenes
{
    class Program
    {
        static void Main(string [] args)
        {
            if(args.Length > 0 && int.TryParse(args[0], out var max))
            {
                var esieve = new Sieve();
                var primes = esieve.Generate(max);

                foreach (var prime in primes)
                    Console.WriteLine(prime);
            }
            else
            {
                Console.WriteLine("You must specify max number!");
            }
        }
    }
}