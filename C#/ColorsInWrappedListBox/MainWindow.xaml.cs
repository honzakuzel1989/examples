using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace ColorsInWrappedListBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class ColorData
        {
            public string Name { get; set; }
            public Brush Color { get; set; }
            public string Code { get; set; }

            public override string ToString()
            {
                return $"{Name} ({Code})";
            }
        }

        public IEnumerable<ColorData> ColorsData { get; set; }
        public ColorData SelectedColorData { set { Title = value.ToString(); } }

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            ColorsData = GetColors();
        }

        private IEnumerable<ColorData> GetColors()
        {
            IList<ColorData> colors = new List<ColorData>();

            PropertyInfo[] brushes = typeof(Brushes).GetProperties();

            foreach (var pi in brushes)
            {
                Brush b = (Brush)pi.GetValue(this);
                if (b != null)
                    colors.Add(new ColorData { Name = $"{pi.Name}", Code = b.ToString(), Color = b });
            }

            return colors;
        }
    }
}
