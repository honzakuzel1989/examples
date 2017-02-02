using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyVariable
{
    class Program
    {


        static void Main(string[] args)
        {
            Foo f = new Foo();
            Parallel.ForEach(Enumerable.Range(0, 10), (_) => Console.WriteLine(f.LazyInt.Value));
            Parallel.ForEach(Enumerable.Range(0, 10), async (_) => Console.WriteLine(await f.LazyTaskInt.Value));


            Console.ReadLine();
        }
    }

    class Foo
    {
        public Lazy<int> LazyInt { get; } = new Lazy<int>(
            // The factory delegate is only executed once
            () => { return 42; });

        public Lazy<Task<int>> LazyTaskInt { get; } = new Lazy<Task<int>>(
            // The factory delegate is only executed once
            async () =>
            {
                await Task.Delay(3000).ConfigureAwait(false);
                // ui or tpool or ... thread
                return 42;
            });
        public Lazy<Task<int>> LazyTaskRunInt { get; } = new Lazy<Task<int>>(
            // it may be better to allways execute the async. delegate on threadpool thread
            () => Task.Run(
                // The factory delegate is only executed once
                async () =>
                {
                    await Task.Delay(3000);
                    // tp thread
                    return 42;
                }
            ));
    }
}
