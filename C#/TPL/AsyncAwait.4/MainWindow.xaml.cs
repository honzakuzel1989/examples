using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            // Start the delay.
            var delayTask = DelayAsync();
            // Wait for the delay to complete.
            //delayTask.Wait();
            b3.Content = "done? no!";
        }

        private async Task DelayAsync()
        {
            await Task.Delay(5000);
            b3.Content = "done!";
        }

        private async void b4_Click(object sender, RoutedEventArgs e)
        {
            // ui thread
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(2500);
            // ui thread
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(new Random().Next(2)).ConfigureAwait(false);
            // threadpool thread
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(2500);
            // threadpool thread
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }

        private async void b5_Click(object sender, RoutedEventArgs e)
        {
            await ReadFileToEndAsync("File1.txt");
        }

        private async Task ReadFileToEndAsync(string filename)
        {
            string file1 = string.Empty;
            using (var sr = new StreamReader(filename))
                file1 = await sr.ReadToEndAsync();
            tb.Text += $"{filename} loaded\n";
            tb.Text += $"Length: {file1.Length}\n";
            //tb.Text += file1;
        }

        private async Task ReadLenghtBytesFromFileAsync(string filename, int length)
        {
            byte[] buffer = new byte[length];
            var s = new FileStream(filename, FileMode.Open);

            //var ac = new AsyncCallback((r) =>
            //{
            //    int count = s.EndRead(r);

            //    Console.WriteLine($"count: {count}");
            //    Console.WriteLine($"data: {Encoding.Default.GetString(buffer)}");

            //    s.Close();
            //    s.Dispose();
            //});

            //s.BeginRead(buffer, 0, buffer.Length, ac, null);

            // OR

            await Task.Factory.FromAsync(s.BeginRead(buffer, 0, buffer.Length, null, null), (r) => s.EndRead(r));

            s.Close();
            s.Dispose();
            tb.Text = Encoding.Default.GetString(buffer);
        }

        private async void b6_Click(object sender, RoutedEventArgs e)
        {
            await ReadLenghtBytesFromFileAsync("File1.txt", 4096);
        }

        private async void b7_Click(object sender, RoutedEventArgs e)
        {
            Task[] t = new Task[2];
            t[0] = ReadLenghtBytesFromFileAsync("File1.txt", 4096);
            t[1] = ReadLenghtBytesFromFileAsync("File2.txt", 4096);

            await Task.WhenAll(t);
        }

        private async void b8_Click(object sender, RoutedEventArgs e)
        {
            List<Task> tasks = new List<Task>();
            foreach (var filename in new[] { "File1.txt", "File2.txt" })
                tasks.Add(ReadFileToEndAsync(filename));
            await Task.WhenAll(tasks);
        }
    }
}
