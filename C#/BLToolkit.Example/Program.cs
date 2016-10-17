using BLToolkit.Data;
using BLToolkit.Data.DataProvider;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLToolkit.Example
{
    class Program
    {
        class Kanal
        {
            public string ID { get; set; }
            public string OZNACENI { get; set; }
        }

        static void Main(string[] args)
        {
            List<Kanal> result = null;

            using (var db = new DbManager(new OdpDataProvider(),
                ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                result = db.SetCommand("SELECT * FROM TKANAL").
                    ExecuteList<Kanal>();
            }


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
