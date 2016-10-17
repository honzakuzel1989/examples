using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Oracle;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrmLite.Example
{
    class Program
    {
        [Alias("TKANAL")]
        class Channel
        {
            // Case insensitive (!)
            public string Id { get; set; }
            public string OZNACENI { get; set; }
            [Alias("OZNACENI")]
            public string Title { get; set; }
            // Raises exception without ignore attribute (!)
            [Ignore]
            public string Xxx { get; set; }
        }

        static void Main(string[] args)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings[nameof(ConnectionString)].ConnectionString;

            var dbfactory = new OrmLiteConnectionFactory(ConnectionString, OracleDialect.Provider);

            IEnumerable<Channel> result;
            using (var db = dbfactory.Open())
            {
                var kanal = new Channel();
                result = db.Select<Channel>();
            }

            int counter = 0;
            foreach (var r in result)
            {
                Console.WriteLine($"id={r.Id},oznaceni={r.Title}");
                counter++;
            }

            Console.WriteLine(counter);
            Console.ReadLine();
        }
    }
}
