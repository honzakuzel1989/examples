using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using System.Reflection;

namespace _13_Reflection
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple=false, Inherited=false)]
    public class FieldNameAttribute : Attribute
    {
        private string name;
        public string Comment;

        public FieldNameAttribute(string name)
        {
            this.name = name;
        }
        
    }

    struct point
    {
        int x;
        int y;
    }

    public class Test : IChapter
    {
        static void Main(string[] args)
        { 
        
        }

        [FieldName("Nazev kapitoly", Comment="...")]
        private string chapterName = "Chapter thirteen - Reflection.";

        public void Run()
        {
            Console.WriteLine(chapterName);
            Console.WriteLine("==============================");

            _1();
            _2();
        }

        private void _1()
        {
            Type t = typeof(double);
            Console.WriteLine("double:\n{0}\n{1}\n{2}\n{3}\n{4}\n{5}", t.IsAbstract, t.IsValueType, t.IsSerializable, t.IsPointer, t.IsClass, t.IsPrimitive);
            t = typeof(int);
            Console.WriteLine("int:\n{0}\n{1}\n{2}\n{3}\n{4}\n{5}", t.IsAbstract, t.IsValueType, t.IsSerializable, t.IsPointer, t.IsClass, t.IsPrimitive);
            t = typeof(point);
            Console.WriteLine("point:\n{0}\n{1}\n{2}\n{3}\n{4}\n{5}", t.IsAbstract, t.IsValueType, t.IsSerializable, t.IsPointer, t.IsClass, t.IsPrimitive);
            Assembly a = t.Assembly;
        }

        private void _2()
        {
            //Assembly ass = Assembly.LoadFile(@"c:\VF\S1101_VFCore\06_VFCoreApp\branches\S1101-1958_kuz1\Bin\Debug\Modules\VFApp.NotifyMessenger.dll");
            //Assembly ass = Assembly.LoadFrom(@"g:\C#\ProgramujemeProfesionalne\08-StringsAndRegexs\bin\Debug\8-StringsAndRegexs.dll");
            //Console.WriteLine(ass.FullName);
            //Attribute[] at = Attribute.GetCustomAttributes(ass);
            //foreach (Attribute a in at)
            //{
            //    Console.WriteLine(a.ToString());
            //}
        }
    }
}
