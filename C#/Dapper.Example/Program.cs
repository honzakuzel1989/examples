using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Example
{
    class Program
    {
        class Kanal
        {
            // Case insensitive (!)
            public string Id { get; set; }
            public string OZNACENI { get; set; }
        }

        static void Main(string[] args)
        {
            OracleConnection Connection = new OracleConnection();
            Connection.ConnectionString = ConfigurationManager.ConnectionStrings[nameof(Connection.ConnectionString)].ConnectionString;
            Connection.Open();

            var result = Connection.Query<Kanal>("select ID, OZNACENI from TKanal");

            int counter = 0;
            foreach(var r in result)
            {
                Console.WriteLine($"id={r.Id},oznaceni={r.OZNACENI}");
                counter++;
            }

            Console.WriteLine(counter);
            Console.ReadLine();

            Connection.Close();
            Connection.Dispose();
        }
    }
}
