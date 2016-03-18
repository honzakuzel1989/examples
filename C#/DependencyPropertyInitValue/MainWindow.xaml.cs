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

namespace DependencyPropertyInitValue
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        // Invoke dependency property changed callback in CustomControl because initial value is different like default value
        // This can be dangerous in some cases (!) - especially in combination with dep. prop. validation callback
        private string _1 = "a";
        public string __1
        {
            get { return _1; }
            set
            {
                _1 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(__1)));
            }
        }

        // Not invoke (!) dependency property changed callback in CustomControl because initial value is same like default value
        private string _2 = "x";
        public string __2
        {
            get { return _2; }
            set
            {
                _2 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(__2)));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
