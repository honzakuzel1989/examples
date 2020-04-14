using System;

namespace SQLParser
{
    static class Program
    {
        static void Main(string[] args)
        {
            var tokens = new Parser()
                .ParseSql("SELECT id, name, address FROM customer WHERE state LIKE '%Praha%' ORDER BY name ASC");

            foreach (var token in tokens)
            {
                Console.WriteLine(token.Start);
                Console.WriteLine(token.End);
                Console.WriteLine(token.Sql);
                Console.WriteLine(token.Token);

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
