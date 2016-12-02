using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace AsyncAwait._4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void b1_Click(object sender, RoutedEventArgs e)
        {
            // long term async operation
            Stopwatch sw = Stopwatch.StartNew();
            await Task.Delay(5000);
            b1.Content = $"done after {sw.ElapsedMilliseconds}ms";
        }

        private async void b2_Click(object sender, RoutedEventArgs e)
        {
            // the better way
            await B2ClickAsync();
        }

        private async Task B2ClickAsync()
        {
            Stopwatch sw = Stopwatch.StartNew();
            await Task.Delay(2500);
            await Task.Delay(2500);
            b2.Content = $"done after {sw.ElapsedMilliseconds}ms";
        }
    }
}
