using System.Windows;

namespace WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OpenSubWindow_Click(object sender, RoutedEventArgs e)
        {
            SubWindow numberInputWindow = new SubWindow(int.Parse(numberTextBlock.Text));
            numberInputWindow.Owner = this;
            numberInputWindow.ShowDialog();

            bool isSave = numberInputWindow.DialogResult.HasValue && numberInputWindow.DialogResult.Value == true;
            if (isSave)
            {
                int enteredNumber = numberInputWindow.EnteredNumber;
                numberTextBlock.Text = enteredNumber.ToString();
            }
        }
    }
}
