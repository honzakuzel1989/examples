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
            var c1 = new Company { Id = 1, Title = "Alza" };
            var c2 = new Company { Id = 2, Title = "CZC" };
            var c3 = new Company { Id = 3, Title = "Mall" };
            var c4 = new Company { Id = 4, Title = "Soft" };

            var companies = new[] { c1, c2, c3, c4 };

            // --

            var p1 = Enumerable.Range(1, 5).
                Select(i => new Person { Id = c1.Id * MULT + i, Company_ID = c1.Id, FullName = $"FullName {c1.Id * MULT + i}" });
            var p2 = Enumerable.Range(1, 3).
                Select(i => new Person { Id = c2.Id * MULT + i, Company_ID = c2.Id, FullName = $"FullName {c2.Id * MULT + i}" });
            var p3 = Enumerable.Range(1, 1).
                Select(i => new Person { Id = c3.Id * MULT + i, Company_ID = c3.Id, FullName = $"FullName {c3.Id * MULT + i}" });

            var persosns = p1.Concat(p2.Concat(p3.Concat(new[]
            {
                new Person { Id = 1, FullName = $"FullName {1}" },
                new Person { Id = 2, FullName = $"FullName {2}" }
            })));

            // --

            Console.WriteLine("=== INNER");
            var innerj1 = companies.InnerJoin(persosns, (c, p) => c.Id == p.Company_ID);
            foreach (var item in innerj1)
                Console.WriteLine(item);

            Console.WriteLine();
            Console.WriteLine("=== LEFT");
            var leftj1 = companies.LeftJoin(persosns, Person.NullObject, (c, p) => c.Id == p.Company_ID);
            foreach (var item in leftj1)
                Console.WriteLine(item);

            Console.WriteLine();
            Console.WriteLine("=== RIGHT");
            var rightj1 = companies.RightJoin(Company.NullObject, persosns, (c, p) => c.Id == p.Company_ID);
            foreach (var item in rightj1)
                Console.WriteLine(item);

            Console.WriteLine();
            Console.WriteLine("=== OUTER");
            var outerj1 = companies.OuterJoin(Company.NullObject, persosns, Person.NullObject, (c, p) => c.Id == p.Company_ID);
            foreach (var item in outerj1)
                Console.WriteLine(item);

            var candidates = new[]
            {
                new Candidate { Id = 1, Fullname = "John Doe" },
                new Candidate { Id = 2, Fullname = "Lily Bush" },
                new Candidate { Id = 3, Fullname = "Peter Drucker" },
                new Candidate { Id = 4, Fullname = "Jane Doe" },
            };

            var employees = new[]
            {
                new Employee { Id = 1, Fullname = "John Doe" },
                new Employee { Id = 2, Fullname = "Jane Doe" },
                new Employee { Id = 3, Fullname = "Michael Scott" },
                new Employee { Id = 4, Fullname = "Jack Sparrow" },
            };

            Console.WriteLine();
            Console.WriteLine("=== INNER");
            var innerj2 = candidates.InnerJoin(employees, (c, p) => c.Fullname == p.Fullname);
            foreach (var item in innerj2)
                Console.WriteLine(item);

            Console.WriteLine();
            Console.WriteLine("=== LEFT");
            var leftj2 = candidates.LeftJoin(employees, (c, p) => c.Fullname == p.Fullname);
            foreach (var item in leftj2)
                Console.WriteLine(item);

            Console.WriteLine();
            var leftj3 = candidates.LeftJoin(employees, (c, p) => c.Fullname == p.Fullname,
                (c, p) => p.Id is null);
            foreach (var item in leftj3)
                Console.WriteLine(item);

            Console.WriteLine();
            Console.WriteLine("=== RIGHT");
            var rightj2 = candidates.RightJoin(employees, (c, p) => c.Fullname == p.Fullname);
            foreach (var item in rightj2)
                Console.WriteLine(item);

            Console.WriteLine();
            var rightj3 = candidates.RightJoin(employees, (c, p) => c.Fullname == p.Fullname, 
                (c, p) => c.Id is null);
            foreach (var item in rightj3)
                Console.WriteLine(item);

            Console.WriteLine();
            Console.WriteLine("=== OUTER");
            var outerj2 = candidates.OuterJoin(employees, (c, p) => c.Fullname == p.Fullname);
            foreach (var item in outerj2)
                Console.WriteLine(item);

            Console.ReadLine();
        }
    }
}
