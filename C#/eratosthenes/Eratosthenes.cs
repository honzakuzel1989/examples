using System;
using System.Linq;
using System.Collections.Generic;

namespace Eratosthenes
{
    public class Sieve
    {
        public IEnumerable<int> Generate(int num)
        {
            var max = num + 1;
            var sieve = Enumerable.Repeat(true, max).ToArray();

            for (int i = 2; i < max; i++)
            {
                if(sieve[i])
                {
                    for (int j = i * 2; j < max; j+=i)
                        sieve[j] = false;
                }
            }

            var primes = new List<int>();
            for (int i = 2; i < max; i++)
            {
                if(sieve[i]) 
                {
                    primes.Add(i);
                }
            }

            return primes;
        }
    }
}
