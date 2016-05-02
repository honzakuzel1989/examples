using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGenerator
{
    interface IWindow
    {
        object DataContext { get; set; }
        void Close();
        void Show();

    }
}
