using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace WherePreformance
{
    class Program
    {
        class Foo
        {
            public Foo()
            {

            }
        }

        static void Main(string[] args)
        {
            int count = 0;
            DateTime dtN = DateTime.Now;
            var range = Enumerable.Range(0, 10000000).Select(i => new WebClient());
            var p = new Predicate<WebClient>(_ => { return true; });

            count = 0;
            dtN = DateTime.Now;
            foreach (var x in range)
            {
                if (!p(x))
                    continue;
                count++;
            }
            Console.WriteLine(DateTime.Now.Subtract(dtN));
            Console.WriteLine(count);

            count = 0;
            dtN = DateTime.Now;
            foreach (var x in range.Where(_ => p(_)))
            {
                count++;
            }
            Console.WriteLine(DateTime.Now.Subtract(dtN));
            Console.WriteLine(count);

            //count = 0;
            //dtN = DateTime.Now;
            //foreach (var x in range.Where(_ => p(_)).ToList())
            //{
            //    count++;
            //}
            //Console.WriteLine(DateTime.Now.Subtract(dtN));
            //Console.WriteLine(count);

            Console.ReadLine();
        }
    }
}
