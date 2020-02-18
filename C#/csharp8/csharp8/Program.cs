using csharp8.Functions;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp8
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var ascData = Enumerable.Range(1, 7).ToArray();
            var asc = new AsyncStreamConsumer<int>(ascData, TimeSpan.FromSeconds(.5));
            //await asc.ConsumeStream();

            var iar = new IndicesAndRanges();
            //iar.PrintExamples();

            var rom = new ReadonlyMembers(1, 7, 12);
            //Console.WriteLine(rom.D);
            //Console.WriteLine(rom.Roots());

            var dim1 = new DefaultInterfaceMethods1(Enumerable.Range(1, 100).ToList());
            var idim1 = (IDefaultInterfaceMethods1)dim1;

            // Call Count in DefaultInterfaceMethods (!)
            //Console.WriteLine(idim1.Count);
            //Console.WriteLine(dim1.Count);

            var dim2 = new DefaultInterfaceMethods2(Enumerable.Range(1, 100).ToList());
            var idim2 = (IDefaultInterfaceMethods1)dim2;

            // It is not possible call Count directly
            //Console.WriteLine(idim2.Count);
            //Console.WriteLine(((IDefaultInterfaceMethods)dim2).Count);

            var pp1 = new PositionalPatterns<char>("jedna dve");
            (var head1, var tail1) = pp1;
            //Console.WriteLine(head1);
            //Console.WriteLine(string.Join(string.Empty, tail1));

            var pp2 = new PositionalPatterns<char>("");
            (var head2, var tail2) = pp2;
            //Console.WriteLine(head2);
            //Console.WriteLine(string.Join(string.Empty, tail2));

            var nol = await UsingDeclarations.nol("jedna" + Environment.NewLine + "dve honza" + Environment.NewLine + "jde");
            //Console.WriteLine(nol);

            //var p0 = StaticLocalFunctions.FibNum(0);
            //var p1 = StaticLocalFunctions.FibNum(1);
            //var p2 = StaticLocalFunctions.FibNum(2);
            //var p7 = StaticLocalFunctions.FibNum(6);
            //Console.WriteLine(p0);
            //Console.WriteLine(p1);
            //Console.WriteLine(p2);
            //Console.WriteLine(p7);

            //Console.WriteLine(string.Join(' ', StaticLocalFunctions.FibSeq(20)));

            //RefStructDispose();

            //var nca1 = new NullcoalescingAssignment();

            //var def = nca1.Add(default);
            //var val = nca1.Add("value");

            //Console.WriteLine(def);
            //Console.WriteLine(val);

            //Console.WriteLine(string.Join(',', nca1.Data));
            //Console.WriteLine();

            //var nca2 = new NullcoalescingAssignment(nca1.Data);

            //nca2.Add("Data");

            //Console.WriteLine(string.Join(',', nca2.Data));

            UnmanagedConstructedTypes.DisplaySize();

            Console.ReadLine();
        }

        private static void RefStructDispose()
        {
            DisposableRefStructs rs = new DisposableRefStructs();
            using (rs)
            { 
                //Dispose
            }
        }
    }
}
