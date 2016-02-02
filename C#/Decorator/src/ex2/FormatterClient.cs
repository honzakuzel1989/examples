using Decorator.src.ex2.props;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.src.ex2
{
    // Decorator client
    class FormatterClient
    {
        public FormatterClient()
        {
            Console.WriteLine("-----\n|Ex2|\n-----");

            string data = "Data";
            Console.WriteLine(new Formatter().Format(data));
            Console.WriteLine(new Head(new Formatter()).Format(data));
            Console.WriteLine(new Tail(new Head(new Formatter())).Format(data));
            Console.WriteLine(new Head(new CRC(new Tail(new Formatter()))).Format(data));
            Console.WriteLine(new Head(new Tail(new CRC(new Formatter()))).Format(data));

            var f = new Formatter();
            var fh = new Head(f);
            var ft = new Tail(f);
            var fc = new CRC(f);
            var fht = new Tail(fh);
            var fth = new Head(ft);
            var fthc = new CRC(fth);
            var fhtc = new CRC(fht);

            Console.WriteLine(f.Format(data));
            Console.WriteLine(fh.Format(data));
            Console.WriteLine(ft.Format(data));
            Console.WriteLine(fc.Format(data));
            Console.WriteLine(fht.Format(data));
            Console.WriteLine(fth.Format(data));
            Console.WriteLine(fthc.Format(data));
            Console.WriteLine(fhtc.Format(data));
        }
    }
}
