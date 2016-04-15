using System;
using System.Collections.Generic;
using System.ComponentModel;
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

// Source: http://stackoverflow.com/questions/21193242/

namespace CheckedListBox 
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private int clickCnt = 0;

        public class CheckboxData
        {
            public int Id { get; set; }
            public string Label { get; set; }
            public bool Checked { get; set; }
        }

        public MainWindow()
        {
            DataContext = this;
            for (int i = 0; i < 50; i++)
                Checkboxes.Add(new CheckboxData { Id = i, Label = $"Checkbox {i} - init" });
        }

        public IList<CheckboxData> Checkboxes { get; set; } = new List<CheckboxData>();

        public event PropertyChangedEventHandler PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ++clickCnt;

            Checkboxes = new List<CheckboxData>();

            for (int i = 0; i < 50; i++)
                Checkboxes.Add(new CheckboxData { Id = i, Label = $"Checkbox {i} - click {clickCnt}" });

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Checkboxes)));
        }
    }
}
