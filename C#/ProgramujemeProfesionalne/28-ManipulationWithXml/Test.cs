using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace _28_ManipulationWithXml
{
    public class Test : IChapter
    {
        public void Run()
        {
            _1();
            _2();
            //_3();
            _4();
            _5();
            //_6();
        }

        private void _1()
        {
            //XmlDocumet implements DOM
            //XmlReader and XmlWriter represents SAX interface
            XmlReader xr = XmlReader.Create("KMNA3.xml");
            while(!xr.EOF)
            {
                //Work with xml  file
                xr.Read();
            }

            //XmlDocument is appropriate for repeat work with xml content
            //XmlReader for simple 
        }

        private void _2()
        {
            XPathDocument doc = new XPathDocument("KMNA3.xml");
            XPathNavigator nav = doc.CreateNavigator();
            //Xpath query
            XPathNodeIterator iter = nav.Select("/Protocol/Block[@name='A']");

            while (iter.MoveNext())
            {
                XPathNodeIterator iter2 = iter.Current.SelectDescendants(XPathNodeType.Element, false);
                while (iter2.MoveNext())
                {
                    Console.WriteLine(iter2.Current.Name);
                }
            }
        }

        private void _3()
        {
            //Optional parameter enable debug information
            XslCompiledTransform t = new XslCompiledTransform();
            //Transformation document!
            t.Load("KMNA3.xsl");
            t.Transform("KMNA.xml", "out.html");
            WebBrowser wb = new WebBrowser();
            wb.Navigate(AppDomain.CurrentDomain.BaseDirectory + "out.html");
        }

        private void _4()
        {
            Car[] c = new Car[] { new Car("Skoda", "Black", 100, "kW"), new Car("Reanult", "Blue", 150, "kW") };
            //Car c = new Car("Skoda", "Black", 100, "kW");

            //Serialization
            TextWriter tw = new StreamWriter("serialization.xml");
            XmlSerializer sr = new XmlSerializer(typeof(Car[]));
            sr.Serialize(tw, c);
            tw.Close();
        }

        private void _5()
        {
            Car[] c;

            //Deserialization
            FileStream fs = new FileStream("serialization.xml", FileMode.Open);
            XmlSerializer sr = new XmlSerializer(typeof(Car[]));
            c = (Car[])sr.Deserialize(fs);
            fs.Close();

            foreach (Car cc in c)
            {
                Console.WriteLine(cc.ToString());
            }
        }

        [System.Xml.Serialization.XmlRootAttribute()]
        public class Car
        {
            //Attribute
            [XmlAttributeAttribute(AttributeName="Brand")]
            public String Brand { get; set; }

            //Element
            [XmlElementAttribute()]
            public String Color { get; set; }

            //Element
            [XmlElementAttribute()]
            public uint Power { get; set; }

            [XmlAttributeAttribute(AttributeName = "Unit")]
            public String Unit { get; set; }

            //Object for serialization must have constructor without parameters
            public Car() : this("Unk", "Unk", 0, "Unk") { }

            public Car(String brand, string color, uint power, String unit)
            {
                Brand = brand;
                Color = color;
                Power = power;
                Unit = unit;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(Brand);
                sb.Append("\n");
                sb.Append(Power);
                sb.Append("\n");
                sb.Append(Color);
                return sb.ToString();
            }
        }

        private void _6()
        {
            System.Threading.Timer t = new System.Threading.Timer((delegate
                {
                    Console.WriteLine("Tick");
                }), null, 0, 10 * 1000);

            System.Timers.Timer ttt = new System.Timers.Timer(1000);
            ttt.Elapsed += new System.Timers.ElapsedEventHandler(ttt_Elapsed);
            ttt.Enabled = true;
        }

        void ttt_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("Tick " + e.SignalTime);
        }
    }
}
