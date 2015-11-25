using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;

namespace _11_Linq
{
    public class Test : IChapter
    {
        public void Run()
        {
            Console.WriteLine("Chapter eleven - Linq.");
            Console.WriteLine("======================");

            _1();
            _2();
            _3();
        }

        List<Person> ps = new List<Person>(new Person[] 
        { 
            new Person("Jan", "Kuzel", "Skalice"), 
            new Person("Pavla", "Stankova", "Boskovice"), 
            new Person("Zuzka", "Bednarova", "Sever"),
            new Person("Karel", "Makovec", "Brno"),
            new Person("Jiri", "Moravec"),
        });

        private void _1()
        {
            List<Person> lp = ps.FindAll(
                delegate(Person p)
                {
                    return p.firstName.Contains('u');
                });

            foreach (Person p in lp)
            {
                Console.WriteLine(p);
            }
        }

        private void _2()
        {
            IEnumerable<string> lp = ps.Where(p => p.firstName[0] == 'J').OrderBy(r => r.firstName).Select(p => p.lastName);

            foreach (string p in lp)
            {
                Console.WriteLine(p);
            }
        }

        private void _3()
        {
            //This query is executed allways in case of need
            var query = from p in ps where p.address.Length == 0 select p;

            //Executing query
            foreach (Person p in query)
            {
                Console.WriteLine(p);
            }

            ps.Add(new Person("Karel", "Novak"));

            //Executing query again
            foreach (Person p in query)
            {
                Console.WriteLine(p);
            }
        }
    }

    internal class Person : IComparable<Person>, IFormattable
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set;  }

        public Person(string firstName, string lastName) : this(firstName, lastName, "")
        {

        }

        public Person(string firstname, string lastname, string address)
        {
            firstName = firstname;
            lastName = lastname;
            this.address = address;
        }

        public int CompareTo(Person other)
        {
            return lastName.CompareTo(other);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return (firstName + " " + lastName.ToUpper());
        }
    }
}
