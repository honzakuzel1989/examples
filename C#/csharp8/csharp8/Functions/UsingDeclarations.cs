using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace csharp8.Functions
{
    class UsingDeclarations
    {
        public static async Task<int> nol(Stream stream)
        {
            using var ms = new StreamReader(stream);
            var content = await ms.ReadToEndAsync();

            return content.Split(Environment.NewLine).Length;
        }

        public static async Task<int> nol(string data)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(data);
            using MemoryStream stream = new MemoryStream(byteArray);
            return await nol(stream);
        }
    }
}
