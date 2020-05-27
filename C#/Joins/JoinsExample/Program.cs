using System;
using System.Linq;

namespace JoinsExample
{
    internal class Program
    {
        private const int MULT = 100;

        protected Program()
        {
        }

        static void Main(string[] args)
        {
            var c1 = new Company { ID = 1, Title = "Alza" };
            var c2 = new Company { ID = 2, Title = "CZC" };
            var c3 = new Company { ID = 3, Title = "Mall" };
            var c4 = new Company { ID = 4, Title = "Soft" };

            var companies = new[] { c1, c2, c3, c4 };

            // --

            var p1 = Enumerable.Range(1, 5).
                Select(i => new Person { ID = c1.ID * MULT + i, Company_ID = c1.ID, FullName = $"FullName {c1.ID * MULT + i}" });
            var p2 = Enumerable.Range(1, 3).
                Select(i => new Person { ID = c2.ID * MULT + i, Company_ID = c2.ID, FullName = $"FullName {c2.ID * MULT + i}" });
            var p3 = Enumerable.Range(1, 1).
                Select(i => new Person { ID = c3.ID * MULT + i, Company_ID = c3.ID, FullName = $"FullName {c3.ID * MULT + i}" });

            var persosns = p1.Concat(p2.Concat(p3.Concat(new[]
            {
                new Person { ID = 1, FullName = $"FullName {1}" },
                new Person { ID = 2, FullName = $"FullName {2}" }
            })));

            // --

            Console.WriteLine("=== INNER");
            //var innerj1 = companies.InnerJoin(c => c.ID, persosns, p => p.Company_ID);
            //foreach (var item in innerj1)
            //    Console.WriteLine(item);

            var innerj2 = companies.InnerJoin(persosns, (c, p) => c.ID == p.Company_ID);
            foreach (var item in innerj2)
                Console.WriteLine(item);

            Console.WriteLine();
            Console.WriteLine("=== LEFT");
            //var leftj1 = companies.LeftJoin(c => c.ID, persosns, p => p.Company_ID, () => Person.NullObject);
            //foreach (var item in leftj1)
            //    Console.WriteLine(item);

            var leftj2 = companies.LeftJoin(persosns, Person.NullObject, (c, p) => c.ID == p.Company_ID);
            foreach (var item in leftj2)
                Console.WriteLine(item);

            Console.WriteLine();
            Console.WriteLine("=== RIGHT");
            //var rightj1 = companies.RightJoin(c => c.ID, persosns, p => p.Company_ID, () => Company.NullObject);
            //foreach (var item in rightj1)
            //    Console.WriteLine(item);

            var rightj2 = companies.RightJoin(Company.NullObject, persosns, (c, p) => c.ID == p.Company_ID);
            foreach (var item in rightj2)
                Console.WriteLine(item);

            Console.WriteLine();
            Console.WriteLine("=== OUTER");
            //var outerj1 = companies.OuterJoin(c => c.ID, () => Company.NullObject, persosns, p => p.Company_ID, () => Person.NullObject);
            //foreach (var item in outerj1)
            //    Console.WriteLine(item);

            var outerj2 = companies.OuterJoin(Company.NullObject, persosns, Person.NullObject, (c, p) => c.ID == p.Company_ID);
            foreach (var item in outerj2)
                Console.WriteLine(item);

            Console.ReadLine();
        }
    }
}
