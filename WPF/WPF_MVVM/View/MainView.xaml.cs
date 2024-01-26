using System.Windows;
using WPF_MVVM.ViewModel;

namespace WPF_MVVM
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel mainViewModel)
        {
            DataContext = mainViewModel;
            InitializeComponent();
        }
    }
}
