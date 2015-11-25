using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using System.Globalization;

namespace _21_Localization
{
    public class Test : IChapter
    {
        public void Run()
        {
            //The language version, which is apply in formating and sorting
            //Control panel -> Regional and Language option
            //CultureInfo.CurrentCulture

            //Property used to language of the UI (depends on the language of the OS)
            //Is possible change this cultere in MUI (multi-language inteface)
            //CultureInfo.CurrentUICulture

            _1();
            _2();
        }

        private void _1()
        {
            double d = 1234567890.1234567890;

            //This example doesn't print group separators
            CultureInfo ci = new CultureInfo("cs-CZ");
            Console.WriteLine(d.ToString("N", ci));

            ci = new CultureInfo("en-CA");
            Console.WriteLine(d.ToString("N", ci));

            ci = new CultureInfo("en-IE");
            Console.WriteLine(d.ToString("N", ci));

            ci = new CultureInfo("de-DE");
            Console.WriteLine(d.ToString("N", ci));

            ci = new CultureInfo("it-IT");
            Console.WriteLine(d.ToString("N", ci));

            ci = new CultureInfo("hi-IN");
            Console.WriteLine(d.ToString("N", ci));

            ci = new CultureInfo("de-CH");
            Console.WriteLine(d.ToString("N", ci));
        }

        private void _2()
        {
            /*
                AllCultures = 7,
                FrameworkCultures = 0x40,
                InstalledWin32Cultures = 4,
                NeutralCultures = 1,
                ReplacementCultures = 0x10,
                SpecificCultures = 2,
                UserCustomCulture = 8,
                WindowsOnlyCultures = 0x20
             */
            string specname = string.Empty;
            foreach (var ci in CultureInfo.GetCultures(CultureTypes.NeutralCultures))
            {
                try 
                { 
                    specname = CultureInfo.CreateSpecificCulture(ci.Name).Name;
                    if(!string.IsNullOrEmpty(ci.Name))
                        Console.WriteLine("{0} - {1} - {2}", ci.Name, specname, ci.EnglishName);
                }
                catch { /* It's not possible create all cultures */ }
            }
        }
    }
}
