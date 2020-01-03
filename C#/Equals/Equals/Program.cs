using System;

namespace Equals
{
    class Program
    {
        //
        // Item 9 in more effective C# 7.0
        //

        static void Main(string[] args)
        {
            // CLASS

            var ps1 = new PointS(0, 0);
            var ps2 = new PointS(0, 0);
            var ps3 = default(PointS);

            Console.WriteLine(nameof(ReferenceEquals));
            Console.WriteLine(Object.ReferenceEquals(ps1, ps1));
            Console.WriteLine(Object.ReferenceEquals(ps1, ps2));
            Console.WriteLine(ps1 is object);
            Console.WriteLine(ps1 is ValueType);
            Console.WriteLine();

            Console.WriteLine(nameof(PointS));
            Console.WriteLine(ps1 == ps2);
            Console.WriteLine(ps1.Equals(ps2));
            Console.WriteLine(ps1.Equals(ps3));
            Console.WriteLine(ps1 == ps3);
            Console.WriteLine(null == ps3);
            Console.WriteLine();

            var pss1 = new PointSS(0, 0);
            var pss2 = new PointSS(0, 0);
            var pss3 = default(PointSS);

            Console.WriteLine(nameof(PointSS));
            Console.WriteLine(pss1 == pss2);
            Console.WriteLine(pss1.Equals(pss2));
            Console.WriteLine(pss1 == pss3);
            Console.WriteLine(null == pss3);
            Console.WriteLine();

            var psss1 = new PointSSS(0, 0);
            var psss2 = new PointSSS(0, 0);
            var psss3 = default(PointSSS);

            Console.WriteLine(nameof(PointSSS));
            Console.WriteLine(psss1 == psss2);
            Console.WriteLine(psss1.Equals(psss2));
            Console.WriteLine(psss1.Equals(psss3));
            Console.WriteLine(psss1 == psss3);
            Console.WriteLine(null == psss3);
            Console.WriteLine();

            // STRUCT

            var pt1 = new PointT(0, 0);
            var pt2 = new PointT(0, 0);
            var pt3 = default(PointT);

            Console.WriteLine(nameof(ReferenceEquals));
            // INFO: ReferenceEquals is never true for ValueTypes
            Console.WriteLine(ValueType.ReferenceEquals(pt1, pt1));
            Console.WriteLine(ValueType.ReferenceEquals(pt1, pt2));
            Console.WriteLine(pt1 is object);
            Console.WriteLine(pt1 is ValueType);
            Console.WriteLine();


            Console.WriteLine(nameof(PointT));
            // INFO: operator == cannot be used without overriding in struct
            Console.WriteLine("not allowed");
            // INFO: this is true without overriding because of struct (value type) and reflection in equals implementation
            Console.WriteLine(pt1.Equals(pt2));
            // INFO: this is true because default values are the same like values in constructor
            Console.WriteLine(pt1.Equals(pt3));
            Console.WriteLine("not allowed");
            Console.WriteLine("not allowed");
            Console.WriteLine();

            var ptt1 = new PointTT(0, 0);
            var ptt2 = new PointTT(0, 0);
            var ptt3 = default(PointTT);

            Console.WriteLine(nameof(PointTT));
            Console.WriteLine("not allowed");
            // INFO: this is true and much more effective because of override
            Console.WriteLine(ptt1.Equals(ptt2));
            Console.WriteLine(ptt1.Equals(ptt3));
            Console.WriteLine("not allowed");
            Console.WriteLine("not allowed");
            Console.WriteLine();

            var pttt1 = new PointTTT(0, 0);
            var pttt2 = new PointTTT(0, 0);
            var pttt3 = default(PointTTT);

            Console.WriteLine(nameof(PointTT));
            Console.WriteLine(pttt1 == pttt2);
            Console.WriteLine(pttt1.Equals(pttt2));
            Console.WriteLine(pttt1.Equals(pttt3));
            Console.WriteLine(pttt1 == pttt3);
            Console.WriteLine(null == pttt3);
            Console.WriteLine();

            Console.ReadLine();
        }
    }

    class PointS
    {
        public PointS(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
    }

    class PointSS : PointS
    {
        public PointSS(int x, int y) : base(x, y)
        {
        }

        public override bool Equals(object obj)
        {
            return obj is PointSS p && p.X == X && p.Y == Y;
        }

        public override int GetHashCode()
        {
            return $"[{X},{Y}]".GetHashCode();
        }
    }

    class PointSSS : PointSS
    {
        public PointSSS(int x, int y) : base(x, y)
        {
        }

        public static bool operator ==(PointSSS p1, PointSSS p2)
        {
            return Equals(p1, p2);
        }

        public static bool operator !=(PointSSS p1, PointSSS p2)
        {
            return !Equals(p1, p2);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    struct PointT
    {
        public PointT(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
    }

    struct PointTT
    {
        public PointTT(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public override bool Equals(object obj)
        {
            return obj is PointTT p && p.X == X && p.Y == Y;
        }

        public override int GetHashCode()
        {
            return $"[{X},{Y}]".GetHashCode();
        }
    }

    struct PointTTT
    {
        public PointTTT(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public static bool operator ==(PointTTT p1, PointTTT p2)
        {
            return Equals(p1, p2);
        }

        public static bool operator !=(PointTTT p1, PointTTT p2)
        {
            return !Equals(p1, p2);
        }

        public override bool Equals(object obj)
        {
            return obj is PointTTT p && p.X == X && p.Y == Y;
        }

        public override int GetHashCode()
        {
            return $"[{X},{Y}]".GetHashCode();
        }
    }
}
