using System;

namespace OwnString
{
    class Program
    {
        static void Main(string[] args)
        {
            // Compile error
            // string i = 42;

            // Implicit operator
            String i = 42;

            Console.WriteLine(i);
            Console.ReadLine();
        }
    }

    class String
    {
        private readonly string _source;

        private String(string source)
        {
            _source = source;
        }

        public static implicit operator String(int i) => new String(i.ToString());

        public override string ToString()
        {
            return _source;
        }
    }
}
