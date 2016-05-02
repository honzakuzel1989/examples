using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGenerator
{
    class MainWindowViewModel : BaseViewModel<MainWindow, MainWindowModel>
    {
        public MainWindowViewModel() : base(new MainWindow(), new MainWindowModel())
        {
        }

        public void Show()
        {
            View.Show();
        }
    }
}
