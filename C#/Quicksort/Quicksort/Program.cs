//#define USE_LISTS
//#define USE_LINQ

using System;
#if USE_LINQ
using System.Linq;
#elif USE_LISTS
using System.Collections.Generic;
#endif

namespace Quicksort
{
    class Program
    {
        static void Main()
        {
            var args = new string[] { "jedna", "dve", "honza", "jde", "nese", "pytel", "mouky", "šel", "za", "ním", "pes" };

#if USE_LISTS
            var aargs = Quicksort(new List<string>(args));
#else
            var aargs = Quicksort(args);
#endif

            foreach (var s in aargs)
                Console.WriteLine(s);

            Console.ReadLine();
        }

#if USE_LINQ
        static T[] Quicksort<T>(T[] values) where T : IComparable<T>
#elif USE_LISTS
        static List<T> Quicksort<T>(List<T> values) where T : IComparable<T>
#else
        static T[] Quicksort<T>(T[] values) where T : IComparable<T>
#endif
        {
            // Stop
#if USE_LINQ
            if (values.Count() <= 1) return values;
#elif USE_LISTS
            if (values.Count <= 1) return values;
#else
            if (values.Length <= 1) return values;
#endif
            // First item
            var pivotIdx = 0;

            // Different approaches how choose pivot
#if USE_RANDOM_PIVOT
            // TODO
#elif USE_MEDIAN_PIVOT
            // TODO
#endif

            // Pivot
            var pivot = values[pivotIdx];

            // Select items to three sub-arrays
#if USE_LINQ
            var smaller = values.Where(v => v.CompareTo(pivot) < 0);
            var pivotAr = new T[] { pivot };
            var bigger = values.Where(v => v.CompareTo(pivot) > 0);

            // Sort and concat sub-arrays
            return Quicksort(smaller.ToArray())
                .Concat(pivotAr)
                .Concat(Quicksort(bigger.ToArray())).ToArray();
#elif USE_LISTS
            List<T> smaller = new List<T>(), pivotAr = new List<T> { pivot }, bigger = new List<T>();
            foreach (var val in values)
            {
                if (val.CompareTo(pivot) < 0) smaller.Add(val);
                if (val.CompareTo(pivot) > 0) bigger.Add(val);
            }

            // Sort and concat sub-arrays
            List<T> result = new List<T>();
            result.AddRange(Quicksort(smaller));
            result.AddRange(pivotAr);
            result.AddRange(Quicksort(bigger));
            return result;
#else
            T[] smaller = new T[] { }, pivotAr = new T[] { pivot }, bigger = new T[] { };
            for (int i = 0; i < values.Length; i++)
            {
                var val = values[i];

                // Not very effective resizing
                if (val.CompareTo(pivot) < 0) { Array.Resize(ref smaller, smaller.Length + 1); smaller[smaller.Length - 1] = val; }
                if (val.CompareTo(pivot) > 0) { Array.Resize(ref bigger, bigger.Length + 1); bigger[bigger.Length - 1] = val; }
            }

            // Sort and concat sub-arrays
            T[] result = new T[smaller.Length + 1 + bigger.Length];
            Quicksort(smaller).CopyTo(result, 0);
            pivotAr.CopyTo(result, smaller.Length);
            Quicksort(bigger).CopyTo(result, smaller.Length + 1);
            return result;
#endif
        }
    }
}
