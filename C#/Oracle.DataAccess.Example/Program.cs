using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.DataAccess.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * This NuGet package contains Oracle.DataAccess.dll (x86 - both the net20 and net40 versions) needed to compile a project that uses Oracle's ODP.NET Library. 
             * Oracle will still need to be installed on the production or development machine in order to connect to Oracle (those libraries are greater than 100MB in size, 
             * so it didn't make sense to include them in a NuGet package), but this package will at least allow the project to be successfully 
             * built (i.e. if you're using a CI server).
             * 
             * Packages :
             * odp.net.x86 - ProcessorArchitecture : X86 = A 32-bit Intel processor, either native or in the Windows on Windows environment on a 64-bit platform (WOW64).
             * odp.net.x64 - ProcessorArchitecture : Amd64 = A 64-bit AMD processor only.
             * Oracle.DataAccess.x86 - exactly (!) same dll as odp.net.x86
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
