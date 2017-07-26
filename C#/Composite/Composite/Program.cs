using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IComponent<string>> loc = new List<IComponent<string>>();

            TextFile textFile1 = new TextFile();
            textFile1.Add(new TextLine { Item = "Line 1" });
            textFile1.Add(new TextLine { Item = "Line 2" });
            textFile1.Add(new TextLine { Item = "Line 3" });
            textFile1.Add(new TextLine { Item = "Line 4" });

            loc.Add(textFile1);
            loc.Add(new TextLine { Item = "Standalone text line 1" });
            loc.Add(new TextLine { Item = "Standalone text line 2" });
            loc.Add(textFile1);

            loc.ForEach(l => l.Display());
            Console.ReadLine();
        }
    }
}
