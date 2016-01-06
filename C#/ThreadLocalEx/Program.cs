using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
/* C# 6 static using */
using static System.Console;

namespace ThreadLocalEx
{
    class Program
    {
        static Random _prng = new Random();

        static void Main(string[] args)
        {
            /*
             * 1
             */

            ThreadLocal<IList<int>> tl = new ThreadLocal<IList<int>>(false);
            WriteLine($"loop index - thread id - items count");

            Action<int> a = (i) =>
            {
                if (!tl.IsValueCreated) tl.Value = new List<int>();
                tl.Value.Add(_prng.Next());
                /* C# 6 string interpolation */
                WriteLine($"{i:D2} - {Thread.CurrentThread.ManagedThreadId:D2} - {tl.Value.Count():D2}");
                Thread.Sleep(250);
            };

            Parallel.For(0, 100, a);

            ReadLine();
        }
    }
}
