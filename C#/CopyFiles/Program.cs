//#define PARALLEL

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CopyFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Enumerable.Range(1, 1024).Select(_ => Guid.NewGuid().ToString()).ToArray();

            try
            {
                DateTime create = DateTime.Now;
#if PARALLEL
                CreateFilesParallel(names);
#else
                CreateFilesSequentiall(names);
#endif
                Console.WriteLine(DateTime.Now.Subtract(create));

                var data = Enumerable.Range(1, 1024).Select(x => (byte)x).ToArray();
                DateTime write = DateTime.Now;
#if PARALLEL
                WriteFilesParallel(names, data);
#else
                WriteFilesSequentiall(names, data);
#endif
                Console.WriteLine(DateTime.Now.Subtract(write));
            }
            finally
            {
                DateTime delete = DateTime.Now;
#if PARALLEL
                DeleteFilesParallel(names);
#else
                DetleteFilesSequentiall(names);
#endif
                Console.WriteLine(DateTime.Now.Subtract(delete));
            }

            Console.WriteLine("--");
            Console.ReadLine();
        }

        private static void DeleteFilesParallel(string[] names)
        {
            names.AsParallel().ForAll(name => File.Delete(name));
        }

        private static void DetleteFilesSequentiall(string[] names)
        {
            foreach (var name in names)
            {
                File.Delete(name);
            }
        }

        private static void WriteFilesParallel(string[] names, byte[] data)
        {
            names.AsParallel().ForAll(name => File.WriteAllBytes(name, data));
        }

        private static void WriteFilesSequentiall(string[] names, byte[] data)
        {
            foreach (var name in names)
            {
                File.WriteAllBytes(name, data);
            }
        }

        private static void CreateFilesSequentiall(string[] names)
        {
            foreach (var name in names)
            {
                File.Create(name).Close();
            }
        }

        private static void CreateFilesParallel(string[] names)
        {
            names.AsParallel().ForAll(name => File.Create(name).Close());
        }
    }
}
