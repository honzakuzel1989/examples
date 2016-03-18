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

namespace DependencyPropertyInitValue
{
    /// <summary>
    /// Interaction logic for CustomControl.xaml
    /// </summary>
    public partial class CustomControl : UserControl
    {
        public static readonly DependencyProperty _1Property = DependencyProperty.Register(nameof(_1), typeof(string), typeof(CustomControl), new UIPropertyMetadata(string.Empty,
            (d, e) =>
            {

            }));

        public static readonly DependencyProperty _2Property = DependencyProperty.Register(nameof(_2), typeof(string), typeof(CustomControl), new UIPropertyMetadata(string.Empty,
            (d, e) =>
            {

            }));

        public string _1
        {
            get { return (string)GetValue(_1Property); }
            set
            {
                BeginAnimation(_1Property, null);
                SetValue(_1Property, value);
            }
        }

        public string _2
        {
            get { return (string)GetValue(_2Property); }
            set
            {
                BeginAnimation(_2Property, null);
                SetValue(_2Property, value);
            }
        }

        public CustomControl()
        {
            InitializeComponent();
        }
    }
}
