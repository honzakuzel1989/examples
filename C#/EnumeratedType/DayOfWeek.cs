using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumeratedType
{
    public static class DayOfWeekExt
    {
        public static string ToReadable(this IEnumerable<DayOfWeek> input)
        {
            return string.Join("\n", input);
        }
    }

    public sealed class DayOfWeek
    {
        private static List<DayOfWeek> DaysOfWeek = new List<DayOfWeek>();

        public int Order { get; private set; }
        private string Name { get; set; }

        public static readonly DayOfWeek
            /* You can set name from resources (language specific - czech in this case) */
            MONDAY = new DayOfWeek(1, "Podnělí"),
            THUESDAY = new DayOfWeek(2, "Úterý"),
            WEDNESDAY = new DayOfWeek(3, "Středa"),
            THURSDAY = new DayOfWeek(4, "Čtvrtek"),
            FRIDAY = new DayOfWeek(5, "Pátek"),
            SATURDAY = new DayOfWeek(6, "Soborta"),
            SUNDAY = new DayOfWeek(7, "Neděle");

        private DayOfWeek(int order, string name)
        {
            Order = order;
            Name = name;

            DaysOfWeek.Add(this);
        }

        public static IEnumerable<DayOfWeek> DaysOrder()
        {
            return DaysOfWeek.OrderBy(d => d.Order);
        }

        public static IEnumerable<DayOfWeek> DaysByName()
        {
            return DaysOfWeek.OrderBy(d => d.Name);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
