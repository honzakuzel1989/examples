using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;

namespace ProgramujemeProfesionalne
{
    class Program
    {
        static Program()
        {
            //This is the methoc that is call before main
        }

        static void Main(string[] args)
        {
            //The array of classes
            IChapter [] chapters = new IChapter []
            {
                new _08_StringsAndRegexs.Test(),
                new _12_MemoryManagmentAndPointers.Test(),
                new _13_Reflection.Test(),
                new _09_Genericity.Test(),
                new _11_Linq.Test(),
                new _07_DelegatesAndEvents.Test(),
                new _29_LinqForXml.Test(),
                new _28_ManipulationWithXml.Test(),
                new _17_Assemblies.Test(),
                new _18_TracingAndEvents.Test(),
                new _19_SubprocessesAndSynchronization.Test(),
                new _20_Security.Test(),
                new _21_Localization.Test(),
            };

            //Foreach class in array run Run() method
            foreach (IChapter ich in chapters)
            {
                ich.Run();
                if (ich is IDisposable) ((IDisposable)ich).Dispose();
            }

            Console.WriteLine("[Enter]");
            Console.ReadLine();
        }
    }
}
