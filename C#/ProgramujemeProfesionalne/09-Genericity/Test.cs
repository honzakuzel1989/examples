using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using System.Collections;

namespace _09_Genericity
{
    public class Test : IChapter
    {
        public void Run()
        {
            Console.WriteLine("Chapter nine - Genericity.");
            Console.WriteLine("==========================");

            _1();
            _2();
            _3();
            _4();
            _5();
        }

        private void _1()
        {
            ArrayList al = new ArrayList() { 1, 2.5f, 3.14, "hello" };

            foreach (var v in al)
            {
                Console.WriteLine(v.GetType().FullName);
            }
        }

        private void _2()
        {
            Point<int> p1 = new Point<int>(0, 0);
            Point<int> p6 = new Point<int>(0, 1);
            Point<int> p3 = new Point<int>(0, 2);
            Point<int> p4 = new Point<int>(0, 3);
            Point<int> p5 = new Point<int>(0, 4);
            Point<double> p2 = new Point<double>(0.25, 0.25);

            Console.WriteLine("[{0}:{1}]", p1.X, p1.Y);
            Console.WriteLine("[{0}:{1}]", p2.X, p2.Y);

            Line<int> line = new Line<int>(new Point<int>[] { p1, p6, p3, p4, p5, p1 });
            for (int i=0, e=line.Length; i<e; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();

            Array.ForEach(new Point<int>[] { p1, p6, p3, p4, p5, p1 }, p => Console.WriteLine(p.X + ":" + p.Y));
        }

        private void _3()
        {
            object l = 0;
            l = StaticDemo<string>.x = "100";
            l = StaticDemo<int>.x = 10;

            Console.WriteLine(l);
        }

        private void _4()
        {
            Nullable<int>[] a = { 1, 2, 3, null, 4, null };
            Nullable<int> x = 0;

            if (x.HasValue)
            {
                Console.WriteLine(x);
            }

            x = null;

            if (!x.HasValue)
            {
                Console.WriteLine("null");
            }
        }

        private void _5()
        {
            double[] ad = { 1.1, 2, 3.3 };
            //AraySegmen is the view to the original array, NOT new array!
            ArraySegment<double> ase = new ArraySegment<double>(ad, 1, 1);

            for (int i = ase.Offset; i < ase.Count + ase.Count; i++ )
            {
                Console.WriteLine(ase.Array[i]);
                ase.Array[i] *= 2;
            }

            foreach (double d in ad)
            {
                Console.WriteLine(d);
            }
        }
    }

    //Genericity class represent point
    internal class Point <T>
    {
        private T x;
        private T y;

        public Point(T x, T y)
        {
            this.x = x;
            this.y = y;
        }

        public T X { get { return x; } }
        public T Y { get { return y; } }

        public override string ToString()
        {
            return String.Format("[{0}:{1}]", x, y);
        }
    }

    internal class Line<T>
    { 
        //Use genericity class represet point for represent line of points
        private Point<T> [] points;
        private int length = 0;

        public Line(Point<T> [] p)
        {
            points = p;
            Length = p.Length;
        }

        public Point<T>[] Points { get { return points; } }

        //....

        public int Length { get { return points.Length; } private set { length = value; } }
    }

    public class StaticDemo<T>
    {
        public static T x;
    }
}
