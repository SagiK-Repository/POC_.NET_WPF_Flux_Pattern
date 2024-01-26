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
using System.Windows.Shapes;

namespace WPF_MVC
{
    /// <summary>
    /// SubWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SubWindow : Window
    {
        public string EnterString { get; set; }

        private Controller _controller;

        public SubWindow(Controller controller)
        {
            _controller = controller;
            EnterString = controller.NumberModel.Number.ToString();
            DataContext = this;
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(EnterString, out int enteredNumber))
                _controller.UpdateNumber(enteredNumber);
            else
                MessageBox.Show("유효한 숫자를 입력해주세요.");

            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) => Close();
    }
}
