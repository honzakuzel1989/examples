using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Massive.Example
{
    class Program
    {
        class Kanal : DynamicModel
        {
            public Kanal() : base("ConnectionString", tableName: "TKANAL", primaryKeyField: "ID")
            {
                
            }
        }

        static void Main(string[] args)
        {
            //var table = new Kanal();
            //var result = table.All

            // same as:

            var db = DynamicModel.Open("ConnectionString");
            var result = db.Query("select * from TKANAL");

            int counter = 0;
            foreach (var r in result)
            {
                Console.WriteLine($"id={r.ID},oznaceni={r.OZNACENI}");
                counter++;
            }

            Console.WriteLine(counter);
            Console.ReadLine();
        }
    }
}
