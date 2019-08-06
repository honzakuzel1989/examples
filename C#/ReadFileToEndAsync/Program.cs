using System;
using System.IO;
using System.Threading.Tasks;

namespace ReadFileToEndAsync
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Object disposed exception
            //Console.WriteLine(await ReadToEndAsync1("coord.test.json"));
            // Ok
            Console.WriteLine(await ReadToEndAsync2("coord.test.json"));

            // Ok
            Console.WriteLine(await BeforeReadToEndAsync1("coord.test.json"));
            // Ok
            Console.WriteLine(await BeforeReadToEndAsync2("coord.test.json"));

            // --
            Console.ReadLine();
        }

        public static Task<string> BeforeReadToEndAsync1(string fileName)
        {
            return ReadToEndAsync2(fileName);
        }

        public static async Task<string> BeforeReadToEndAsync2(string fileName)
        {
            return await ReadToEndAsync2(fileName);
        }

        //public static Task<string> ReadToEndAsync1(string fileName)
        //{
        //    using (var sr = new StreamReader(fileName))
        //        return sr.ReadToEndAsync();
        //}

        public static async Task<string> ReadToEndAsync2(string fileName)
        {
            using (var sr = new StreamReader(fileName))
                return await sr.ReadToEndAsync();
        }
    }
}
