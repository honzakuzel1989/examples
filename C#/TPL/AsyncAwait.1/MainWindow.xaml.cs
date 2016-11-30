using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
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

namespace AsyncAwait._1
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

        private async void aa1_Click(object sender, RoutedEventArgs e)
        {
            await Task.Delay(5000);
            aa1.Content = "done";
        }

        private void aa2_Click(object sender, RoutedEventArgs e)
        {
            Task.Delay(5000);
            aa2.Content = "done";
        }

        private void aa3_Click(object sender, RoutedEventArgs e)
        {
            Task.Delay(5000).Wait();
            aa3.Content = "done";
        }

        private void aa4_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            new WebClient().DownloadFile(@"http://honzakuzel.eu/pic/gmail.png", "gmail.png");
            sw.Stop();

            aa4.Content = sw.ElapsedMilliseconds;
        }

        private void aa5_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            new WebClient().DownloadFileAsync(new Uri(@"http://honzakuzel.eu/pic/gmail.png"), "gmail.png");
            sw.Stop();

            aa5.Content = sw.ElapsedMilliseconds;
        }

        private void aa6_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            Task t = new WebClient().DownloadFileTaskAsync(@"http://honzakuzel.eu/pic/gmail.png", "gmail.png");
            sw.Stop();

            aa6.Content = sw.ElapsedMilliseconds;
        }

        private async void aa7_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            await new WebClient().DownloadFileTaskAsync(@"http://honzakuzel.eu/pic/gmail.png", "gmail.png");
            sw.Stop();

            aa7.Content = sw.ElapsedMilliseconds;
        }

        private void aa8_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            Task.Run(() => new WebClient().DownloadFile(@"http://honzakuzel.eu/pic/gmail.png", "gmail.png"));
            sw.Stop();

            aa8.Content = sw.ElapsedMilliseconds;
        }
    }
}
