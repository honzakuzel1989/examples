using System;
using SemanticComparison;

namespace SemanticComparisonLibraryExample
{
    static class Program
    {
        static void Main(string[] args)
        {
            Student st1 = new Student();
            st1.ID = 20;
            st1.Name = "ligaoren";

            Student st2 = new Student();
            st2.ID = 20;
            st2.Name = "ligaoren";

            var expectedStudent = new Likeness<Student, Student>(st1);

            Console.WriteLine(Equals(expectedStudent, st2));
            Console.WriteLine(Equals(st1, st2));

            Console.ReadLine();
        }
    }
}
