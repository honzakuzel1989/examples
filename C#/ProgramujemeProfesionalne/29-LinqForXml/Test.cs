using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using Interfaces;

namespace _29_LinqForXml
{
    public class Test : IChapter
    {
        private XDocument xdoc;

        public void Run()
        {
            _1();
            _2();
        }

        private void _1()
        {
            //Load and show xml document
            xdoc = XDocument.Load(@"KMNA3.xml");
            Console.WriteLine(xdoc.ToString());
        }

        private void _2()
        {
            //Protocol name attribute
            string Protokol_name = xdoc.Element("Protocol").Attribute("name").Value;

            //Protokol blocks
            var blocks = from b in xdoc.Descendants("Block")
                        select new
                            {
                                Block_name = b.Attribute("name").Value,
                                Block_desc = b.Attribute("desc").Value,
                                //Elements for future use
                                Message = b.Element("Message"),
                                Request = b.Element("Request"),
                            };

            Console.WriteLine("Protokol" + Protokol_name);
            foreach (var item in blocks)
            {
                Console.WriteLine(item.Block_name + " " + item.Block_desc );
            }
        }
    }
}
