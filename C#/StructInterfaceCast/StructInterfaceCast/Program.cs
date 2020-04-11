using System;

namespace StructInterfaceCast
{
    class Program
    {
        static void Main(string[] args)
        {
            const int size = 42;

            var cline = new CLine(size);
            var sline = new SLine(size);

            PrintSize(cline, sline);

            const int newsize = 17;

            cline.Resize(newsize);
            sline.Resize(newsize);

            PrintSize(cline, sline);

            var isline = (IShape)sline;
            var icline = (IShape)cline;

            PrintSize(icline, isline);
            PrintSize(cline, sline);

            const int newnewsize = 7;

            icline.Resize(newnewsize);
            isline.Resize(newnewsize);

            // !
            PrintSize(icline, isline);
            PrintSize(cline, sline);

            var newicline = icline.ResizeImutable(newnewsize);
            var newisline = isline.ResizeImutable(newnewsize);

            PrintSize(newicline, newisline);
            Console.ReadLine();
        }

        private static void PrintSize(IShape cline, IShape sline)
        {
            Console.WriteLine(cline.Name);
            Console.WriteLine(cline.Size);

            Console.WriteLine(sline.Name);
            Console.WriteLine(sline.Size);

            Console.WriteLine();
        }
    }

    interface IShape
    {
        public string Name { get; }
        public int Size { get; }

        public void Resize(int size);
        public IShape ResizeImutable(int size);
    }

    class CLine : IShape
    {
        public string Name => "cline";
        public int Size { get; private set; }

        public CLine(int size)
        {
            Size = size;
        }

        public void Resize(int size)
        {
            Size = size;
        }

        public IShape ResizeImutable(int size)
        {
            return new CLine(size);
        }
    }

    struct SLine : IShape
    {
        public string Name => "sline";
        public int Size { get; private set; }

        public SLine(int size)
        {
            Size = size;
        }

        public void Resize(int size)
        {
            Size = size;
        }

        public IShape ResizeImutable(int size)
        {
            return new SLine(size);
        }
    }
}
