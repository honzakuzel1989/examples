using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGenerator
{
    class DirectoryInfo
    {

    }

    class MainWindowViewModel : BaseViewModel<MainWindow, MainWindowModel>
    {
        string path = "D:\\VFTFS\\_EDU Upgrade CISRK\\0606001_Operator";
        public string Path
        {
            get { return path; }
            set
            {
                path = value;
                Notify();
                ShowDirectories();
            }
        }

        public ICollection<DirectoryInfo> Directories { get; set; }

        public Command ChooseDirectoryCommand { get; }

        public MainWindowViewModel() : base(new MainWindow(), new MainWindowModel())
        {
            ChooseDirectoryCommand = new Command(ChooseDirectoryExecute);

            ShowDirectories();
        }

        public void Show()
        {
            View.Show();
        }

        private void ChooseDirectoryExecute(object parameter)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Path = dialog.SelectedPath;
            }
        }

        private void ShowDirectories()
        {
            string[] dirs = Directory.GetDirectories(Path);
        }
    }
}
