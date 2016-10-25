using Base;
using Inherited;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Source s = new Source();

            // Simple mapping
            DestinationBase db = DataMapping.Map(s);
            Debug.Assert(db.VALUE == s.CVALUE && s.CVALUE == 42);

            // Mapping to inherited class
            // I want this as simple as possible (!!!!)
            //      without double mapping, DI, ...
            DestinationDerived dd = DataMapping.Map<DestinationDerived>(s);
            Debug.Assert(db.VALUE == s.CVALUE && s.CVALUE == 42);
        }
    }
}
