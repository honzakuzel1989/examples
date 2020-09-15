using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace NotifyCompletion
{
    // source: https://tooslowexception.com/author/kkokosa/
    class Program
    {
        static async Task Main(string[] args)
        {
            bool t = true, f = false;

            Console.WriteLine(await t);
            Console.WriteLine(await f);

            Console.ReadLine();
        }
    }

    internal static class BoolExtensions
    {
        public static FunnyBoolAwaiter GetAwaiter(this bool value) 
            => new FunnyBoolAwaiter(value);
    }

    internal class FunnyBoolAwaiter : INotifyCompletion
    {
        private readonly bool _value;
        public FunnyBoolAwaiter(bool value) => _value = value;

        public bool IsCompleted => true;
        // Never called
        public void OnCompleted(Action continuation) { } 
        public bool GetResult() => !_value;
    }
}
