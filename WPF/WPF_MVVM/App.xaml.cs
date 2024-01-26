using System.Windows;
using WPF_MVVM.ViewModel;

namespace WPF_MVVM
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainViewModel viewModel = new MainViewModel();
            MainWindow mainWindow = new MainWindow(viewModel);
            mainWindow.Show();
        }
    }
}
