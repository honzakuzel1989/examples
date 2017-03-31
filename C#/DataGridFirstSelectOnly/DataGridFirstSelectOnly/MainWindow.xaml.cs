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

namespace DataGridFirstSelectOnly
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public class Item
        {
            public int Id { get; set; }
            public string IdStr => Id.ToString();
            public string Description => $"Id: {Id}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private int position = 0;

        public IEnumerable<Item> items;
        public IEnumerable<Item> Items
        {
            get { return items; }
            set
            {
                items = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Items)));
            }
        }

        private Item selectedItem;
        public Item SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedItem)));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Items = Enumerable.Range(0, 100).Select(x => new Item { Id = x }).ToList();
            SelectedItem = Items.First();
        }

        private void Button_Minus_Click(object sender, RoutedEventArgs e)
        {
            if (--position < 0) position = 0;
            SelectedItem = Items.ElementAt(position);
        }

        private void Button_Plus_Click(object sender, RoutedEventArgs e)
        {
            if (++position > Items.Count() - 1) position = Items.Count() - 1;
            SelectedItem = Items.ElementAt(position);
        }
    }
}
