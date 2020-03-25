using System;
using KellermanSoftware.CompareNetObjects;

namespace CompareNetObjectsLibraryExample
{
    enum SexTypes
    {
        MALE,
        FEMALE
    }

    struct Person
    {
        public SexTypes SexType { get; set; }
        public string Name { get; set; }
    }

    class Test
    {
        int field { get; }
        public double Property { get; set; }
        public string Description { get; set; }

        public Person Person { get; set; }

        public Test()
        {
            field = DateTime.Now.Millisecond;
        }
    }

    static class Program
    {
        static void Main(string[] args)
        {
            CompareLogic compareLogic = new CompareLogic();

            var test1 = new Test();
            test1.Description = "test 1";
            test1.Property = 42;
            test1.Person = new Person { Name = "Honza", SexType = SexTypes.MALE };

            var test2 = new Test();
            test2.Description = "test 2";
            test2.Property = 42;
            test2.Person = new Person { Name = "Alena", SexType = SexTypes.FEMALE };

            ComparisonResult result1 = compareLogic.Compare(test1, test2);

            if (!result1.AreEqual)
            {
                Console.WriteLine(result1.DifferencesString);
            }

            compareLogic.Config.MaxDifferences = int.MaxValue;
            ComparisonResult result2 = compareLogic.Compare(test1, test2);

            if (!result2.AreEqual)
            {
                Console.WriteLine(result2.DifferencesString);
            }

            compareLogic.Config.ComparePrivateProperties = true;
            ComparisonResult result3 = compareLogic.Compare(test1, test2);

            if (!result3.AreEqual)
            {
                Console.WriteLine(result3.DifferencesString);
            }

            Console.ReadLine();
        }
    }
}
