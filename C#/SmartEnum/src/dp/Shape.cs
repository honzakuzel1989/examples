using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Source: http://blog.falafel.com/introducing-type-safe-enum-pattern/
namespace SmartEnum.src.dp
{
    /*
     * Classic way
     */
    //public enum Shape
    //{
    //    Circle,
    //    Square,
    //    Rectangle
    //}

    /*
     * Smart way
     *
     * The class is declared sealed to prevent inheritance.
     */
    public sealed class Shape
    {
        // Any available fields on a Shape instance are public readonly fields.
        public readonly String Name;
        public readonly String Description;

        // Every kind of Shape desired is declared as a public static readonly field.
        public static readonly Shape Circle;
        public static readonly Shape Square;
        public static readonly Shape Rectangle;

        static Shape()
        {
            Circle = new Shape("Circle", "first smart enum shape item");
            Square = new Shape("Square", "second smart enum shape item");
            Rectangle = new Shape("Rectangle", "third smart enum shape item");
        }

        // The constructor is made private since all Shapes are declared in the class itself.
        private Shape(string name, string desctiption)
        {
            Name = name;
            Description = desctiption;
        }

        public static IEnumerable<Shape> GetAllShapes()
        {
            yield return Circle;
            yield return Square;
            yield return Rectangle;
        }

        public static Shape GetShapeByName(string name)
        {
            return GetAllShapes().Where(s => s.Name == name).FirstOrDefault();
        }

        // Since this is simply a C# class, developers can define any methods they want, override ToString(), and easily unit test any code in this class.
        public override string ToString()
        {
            return $"Smart shape {Name} ({Description})";
        }

    }
}
