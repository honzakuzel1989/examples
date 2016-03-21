using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposeCall
{
    class CustomStreamReader : StreamReader
    {
        public CustomStreamReader(string path) : base(path)
        {
            Console.WriteLine("Create CustomStreamReader");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            Console.WriteLine("Dispose CustomStreamReader");
        }
    }
}
