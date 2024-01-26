using System.Windows;

namespace WPF
{
    public partial class SubWindow : Window
    {
        public string EnterString { get; set; }
        public int EnteredNumber { get; private set; }

        public SubWindow(int enterNumber)
        {
            EnteredNumber = enterNumber;
            EnterString = EnteredNumber.ToString();
            DataContext = this;
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(EnterString, out int enteredNumber))
            {
                EnteredNumber = enteredNumber;
                DialogResult = true;
            }
            else
                MessageBox.Show("유효한 숫자를 입력해주세요.");
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
