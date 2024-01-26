using System.Windows;
using System.Windows.Input;

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
