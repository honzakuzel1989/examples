using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Data.Example
{
    class Program
    {
        class TKANAL
        {
            // Case insensitive (!)
            public string ID { get; set; }
            public string OZNACENI { get; set; }
        }

        static void Main(string[] args)
        {
            var db = Database.Open();
            List<TKANAL> result = db.TKANAL.All();

            int counter = 0;
            foreach (var r in result)
            {
                Console.WriteLine(r.ID);
                counter++;
            }

            Console.WriteLine(counter);
            Console.ReadLine();
        }
    }
}
