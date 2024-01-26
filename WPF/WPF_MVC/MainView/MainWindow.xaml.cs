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

namespace WPF_MVC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NumberModel _model;
        private Controller _controller;

        public MainWindow()
        {
            InitializeComponent();
            _model = new NumberModel();
            _controller = new Controller(_model);
            DataContext = _model;
        }

        private void OpenSubWindow_Click(object sender, RoutedEventArgs e)
        {
            var numberInputWindow = new SubWindow(_controller);
            numberInputWindow.ShowDialog();

            // dialog 이후 작업은 SubWindow에 넘겨준 Controller가 작업하기에 제거.
        }
    }
}
