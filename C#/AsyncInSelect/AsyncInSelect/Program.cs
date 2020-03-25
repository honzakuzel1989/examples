using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInSelect
{
    static class Program
    {
        // Presumption:
        // 
        //The call to Select is valid.These two lines are essentially identical:
        //
        //events.Select(async ev => await ProcessEventAsync(ev))
        //events.Select(ev => ProcessEventAsync(ev))
        //
        //(There's a minor difference regarding how a synchronous exception would be thrown from ProcessEventAsync.)

        static async Task Main(string[] args)
        {
            var numbers = Enumerable.Range(1, 10);

            // Two options mentioned in presumption
            // 1
            Console.WriteLine($"==================== 1");
            Console.WriteLine($"=== {DateTime.Now}");
            var tasks1 = numbers.Select(async ev => await ProcessEventAsync(ev));
            await Task.WhenAll(tasks1);

            // 2
            Console.WriteLine($"==================== 2");
            Console.WriteLine($"=== {DateTime.Now}");
            var tasks2 = numbers.Select(ev => ProcessEventAsync(ev));
            await Task.WhenAll(tasks2);

            try
            {
                // Two options mentioned in presumption - exception
                // 1
                Console.WriteLine($"==================== 1 ex");
                Console.WriteLine($"=== {DateTime.Now}");
                var tasks1ex = numbers.Select(async ev => await ProcessEventAsyncEx(ev));
                await Task.WhenAll(tasks1ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                //System.ApplicationException: ev: 1
                //   at AsyncInSelect.Program.ProcessEventAsyncEx(Int32 ev) in C:\Users\jan.kuzel\source\repos\AsyncInSelect\AsyncInSelect\Program.cs:line 76
                //   at AsyncInSelect.Program.<>c.<<Main>b__0_2>d.MoveNext() in C:\Users\jan.kuzel\source\repos\AsyncInSelect\AsyncInSelect\Program.cs:line 38
                //--- End of stack trace from previous location where exception was thrown ---
                //   at AsyncInSelect.Program.Main(String[] args) in C:\Users\jan.kuzel\source\repos\AsyncInSelect\AsyncInSelect\Program.cs:line 39
            }

            try
            {
                // 2
                Console.WriteLine($"==================== 2 ex");
                Console.WriteLine($"=== {DateTime.Now}");
                var tasks2ex = numbers.Select(ev => ProcessEventAsyncEx(ev));
                await Task.WhenAll(tasks2ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                //System.ApplicationException: ev: 1
                //   at AsyncInSelect.Program.ProcessEventAsyncEx(Int32 ev) in C:\Users\jan.kuzel\source\repos\AsyncInSelect\AsyncInSelect\Program.cs:line 82
                //   at AsyncInSelect.Program.Main(String[] args) in C:\Users\jan.kuzel\source\repos\AsyncInSelect\AsyncInSelect\Program.cs:line 57
            }

            var tasks1aex = numbers.Select(async ev => await ProcessEventAsyncEx(ev));
            var task1aex = Task.WhenAll(tasks1aex);

            try
            {
                // Two options mentioned in presumption - aggregate exception
                // 1
                Console.WriteLine($"==================== 1 agg ex");
                Console.WriteLine($"=== {DateTime.Now}");
                await task1aex;
            }
            catch (Exception) when (task1aex.Exception != null)
            {
                foreach (var iex in task1aex.Exception.InnerExceptions)
                    Console.WriteLine(iex);

                //System.ApplicationException: ev: 2
                //   at AsyncInSelect.Program.ProcessEventAsyncEx(Int32 ev) in C:\Users\jan.kuzel\source\repos\AsyncInSelect\AsyncInSelect\Program.cs:line 128
                //   at AsyncInSelect.Program.<>c.<<Main>b__0_2>d.MoveNext() in C:\Users\jan.kuzel\source\repos\AsyncInSelect\AsyncInSelect\Program.cs:line 73
                //--- End of stack trace from previous location where exception was thrown ---
                //   at AsyncInSelect.Program.Main(String[] args) in C:\Users\jan.kuzel\source\repos\AsyncInSelect\AsyncInSelect\Program.cs:line 82
                //System.ApplicationException: ev: 8
                //   at AsyncInSelect.Program.ProcessEventAsyncEx(Int32 ev) in C:\Users\jan.kuzel\source\repos\AsyncInSelect\AsyncInSelect\Program.cs:line 128
                //   at AsyncInSelect.Program.<>c.<<Main>b__0_2>d.MoveNext() in C:\Users\jan.kuzel\source\repos\AsyncInSelect\AsyncInSelect\Program.cs:line 73
            }

            var tasks2aex = numbers.Select(ev => ProcessEventAsyncEx(ev));
            var task2aex = Task.WhenAll(tasks2aex);

            try
            {
                // 2
                Console.WriteLine($"==================== 2 agg ex");
                Console.WriteLine($"=== {DateTime.Now}");
                await task2aex;
            }
            catch (Exception) when (task2aex.Exception != null)
            {
                foreach (var iex in task2aex.Exception.InnerExceptions)
                    Console.WriteLine(iex);

                //System.ApplicationException: ev: 2
                //   at AsyncInSelect.Program.ProcessEventAsyncEx(Int32 ev) in C:\Users\jan.kuzel\source\repos\AsyncInSelect\AsyncInSelect\Program.cs:line 137
                //   at AsyncInSelect.Program.Main(String[] args) in C:\Users\jan.kuzel\source\repos\AsyncInSelect\AsyncInSelect\Program.cs:line 107
                //System.ApplicationException: ev: 3
                //   at AsyncInSelect.Program.ProcessEventAsyncEx(Int32 ev) in C:\Users\jan.kuzel\source\repos\AsyncInSelect\AsyncInSelect\Program.cs:line 137
                //System.ApplicationException: ev: 10
                //   at AsyncInSelect.Program.ProcessEventAsyncEx(Int32 ev) in C:\Users\jan.kuzel\source\repos\AsyncInSelect\AsyncInSelect\Program.cs:line 137
            }

            Console.ReadLine();
        }

        private static async Task<int> ProcessEventAsync(int ev)
        {
            var delay = TimeSpan.FromSeconds(new Random().Next(1, 4));
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()} ProcessEventAsync {ev} delay {delay}");
            await Task.Delay(delay);
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()} ProcessEventAsync {ev}");
            return await Task.FromResult(ev);
        }

        private static async Task<int> ProcessEventAsyncEx(int ev)
        {
            var delay = TimeSpan.FromSeconds(new Random().Next(1, 4));
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()} ProcessEventAsync {ev} delay {delay}");
            if (delay.TotalSeconds == 1)
            {
                Console.WriteLine($"{DateTime.Now.ToLongTimeString()} ProcessEventAsync {ev} throw");
                throw new ApplicationException($"ev: {ev.ToString()}");
            }
            else
            {
                await Task.Delay(delay);
                Console.WriteLine($"{DateTime.Now.ToLongTimeString()} ProcessEventAsync {ev}");
            }
            return await Task.FromResult(ev);
        }
    }
}
