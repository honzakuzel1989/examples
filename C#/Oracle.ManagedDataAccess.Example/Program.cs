using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.ManagedDataAccess.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            /* REQUIREMENTS:
             * .... You will also need access to Oracle Database 10g Release 2 (10.2) or later...
             */
            OracleConnection Connection = new OracleConnection();
            Connection.ConnectionString = ConfigurationManager.ConnectionStrings["cs2"].ConnectionString;
            Connection.Open();

            OracleCommand cmd = new OracleCommand
            {
                CommandText = "select * from FRM2_MEAS",
                Connection = Connection
            };

            var result = cmd.ExecuteReader();

            int counter = 0;
            while (result.Read())
            {
                string item = result["MPACKAGE"]?.ToString() ?? "<null>";
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
