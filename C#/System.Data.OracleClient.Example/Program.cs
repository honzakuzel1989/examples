using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Data.OracleClient.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            /* OBSOLETE:
             * The types in System.Data.OracleClient are deprecated. The types remain supported in the current version of
             * .NET Framework but will be removed in a future release. Microsoft recommends that you use a third-party Oracle provider.
             */
            OracleConnection Connection = new OracleConnection();
            Connection.ConnectionString = ConfigurationManager.ConnectionStrings[nameof(Connection.ConnectionString)].ConnectionString;
            Connection.Open();

            OracleCommand cmd = new OracleCommand
            {
                CommandText = "select OZNACENI from TKANAL",
                Connection = Connection
            };

            var result = cmd.ExecuteReader();

            int counter = 0;
            while (result.Read())
            {
                string item = result["OZNACENI"]?.ToString() ?? "<null>";
                Console.WriteLine(item);
                counter++;
            }

            Console.WriteLine(counter);
            Console.ReadLine();

            Connection.Close();
            Connection.Dispose();
        }
    }
}
