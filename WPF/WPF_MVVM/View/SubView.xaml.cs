using System.Windows;
using WPF_MVVM.ViewModel;

namespace WPF_MVVM.View
{
    public partial class SubView : Window
    {
        public SubView(SubViewModel subViewModel)
        {
            DataContext = subViewModel;
            InitializeComponent();
        }
    }
}
