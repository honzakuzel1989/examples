using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomDataGridHeader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Information
        {
            public int Block { get; set; }
            public string Channel { get; set; }
            public double Value { get; set; }
            public string Unit { get; set; }
            public ICollection<Valve> Valves { get; set; }
            public string Temperature { get; set; }
            public string Flow { get; set; }
            public int Control { get; set; }
            public int Period { get; set; }
        }

        public class Valve
        {
            public string Header { get; set; }
            public Color Value { get; set; }
        }

        public ICollection<Information> Informations { get; set; }

        public string H { get; set; } = "Header";

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            FillInformations();
        }

        private void FillInformations()
        {
            Informations = new List<Information>
            {
                new Information {Block = 1, Channel = "1XA0161", Unit = "Bq/m3", Valves = new List<Valve>
                {
                    new Valve {Header="1", Value=Colors.Green },
                    new Valve {Header="2", Value=Colors.Red },
                    new Valve {Header="3", Value=Colors.Blue },
                }},
                new Information {Block = 2, Channel = "2XA0427", Unit = "Bq/m3", Valves = new List<Valve>
                {
                    new Valve {Header="1", Value=Colors.Green },
                    new Valve {Header="2", Value=Colors.Red },
                    new Valve {Header="3", Value=Colors.Blue },
                }},
                new Information {Block = 3, Channel = "3XA0161", Unit = "Bq/m3", Valves = new List<Valve>
                {
                    new Valve {Header="1", Value=Colors.Green },
                    new Valve {Header="2", Value=Colors.Red },
                    new Valve {Header="3", Value=Colors.Blue },
                }},
                new Information {Block = 4, Channel = "4XA0427", Unit = "Bq/m3", Valves = new List<Valve>
                {
                    new Valve {Header="1", Value=Colors.Green },
                    new Valve {Header="2", Value=Colors.Red },
                    new Valve {Header="3", Value=Colors.Blue },
                }},
            };
        }
    }
}
