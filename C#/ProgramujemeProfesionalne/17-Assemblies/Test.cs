using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using System.CodeDom.Compiler;
using Microsoft.CSharp;

namespace _17_Assemblies
{
    public class Test : IChapter
    {
        private string code;

        public void Run()
        {
            //ildasm = IL Disasembler fot the examine IL in assemblies

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("public static class Driver");
            sb.AppendLine("{");
            sb.AppendLine("public static void Run()");
            sb.AppendLine("{");
            sb.AppendLine("string msg = \"Hello from Run\";");
            sb.AppendLine("Console.WriteLine(msg);");
            sb.AppendLine("}");
            sb.AppendLine("}");
            code = sb.ToString();

            _1();
            _2();
        }

        private void _1()
        {
            

            CodeDriver cd = new CodeDriver();
            cd.CompileAndRun(code);
        }

        private void _2()
        { 
            //Create new application domain
            //Main advantage the domain is release assembly before unload domain
            AppDomain codeDomain = AppDomain.CreateDomain("CodeDriver");
            CodeDriver cd = (CodeDriver)codeDomain.CreateInstanceAndUnwrap("17-Assemblies", "_17_Assemblies.CodeDriver");
            cd.CompileAndRun(code);
        }
    }

    public class CodeDriver : MarshalByRefObject
    {
        public void CompileAndRun(string code)
        {
            CompilerResults cr = null;
            using (CSharpCodeProvider provider = new CSharpCodeProvider())
            {
                CompilerParameters option = new CompilerParameters();
                option.GenerateInMemory = true;

                cr = provider.CompileAssemblyFromSource(option, code);
            }

            if (cr.Errors.HasErrors || cr.Errors.HasWarnings)
            {
                foreach (CompilerError err in cr.Errors)
                {
                    Console.WriteLine(err);
                }
            }
            else
            {
                Type dt = cr.CompiledAssembly.GetType("Driver");
                dt.InvokeMember("Run", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.InvokeMethod, null, null, null);
            }
        }
    }
}
