using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Interfaces;


namespace _08_StringsAndRegexs
{
    public class Test : IChapter
    {
        public void Run()
        {
            Console.WriteLine("Chapter eight - Strings and regular expresions.");
            Console.WriteLine("===============================================");

            //\b = boundary
            //\S = not whitespace
            _1("is");
            _1(@"s\b");
            _1(@"\bs\S*[lg]\b");
            //?: = don't save this group
            //? = zero or one occurrence
            //!This pattern is not perfect!
            _2(@"\b(?:(http)://)?(\S+)(?::(\S+))?\b");
        }

        private void _1(string pattern)
        {
            Console.WriteLine();

            //Finding pattern
            string p = pattern;
            string text = "This is something special for you.";

            Console.Write("String:{0}\nPattern:{1}\nIndexes:", text, p);

            MatchCollection mc = Regex.Matches(text, p, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
            foreach (Match nextMach in mc)
            {
                Console.Write("{0},", nextMach.Index);
                Console.Write("{0} ", nextMach.Value);
            }

            Console.WriteLine();
        }

        private void _2(string pattern)
        {
            Console.WriteLine();

            //Finding pattern
            string p = pattern;
            string text = @"http://www.seznam.cz:80, http://www.wrox.com, www.centrum.cz, www.atlas.cs:12345";

            Console.Write("String:{0}\nPattern:{1}\nIndexes:", text, p);

            MatchCollection mc = Regex.Matches(text, p, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
            foreach (Match nextMach in mc)
            {
                Console.Write("{0},", nextMach.Index);
                Console.Write("{0} ", nextMach.Value);
                Console.WriteLine();

                foreach (Group v in nextMach.Groups)
                {
                    Console.WriteLine("{0}", v);
                }
            }

            Console.WriteLine();
        }
    }
}
