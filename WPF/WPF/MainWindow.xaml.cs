using System.ComponentModel;
using System.Windows;

namespace WPF
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _numberSTring;
        public string NumberString
        {
            get { return _numberSTring; }
            set
            {
                _numberSTring = value;
                OnPropertyChanged(nameof(NumberString));
            }
        }
        public MainWindow()
        {
            NumberString = "0";
            DataContext = this;
            InitializeComponent();
        }
        private void OpenSubWindow_Click(object sender, RoutedEventArgs e)
        {
            SubWindow numberInputWindow = new SubWindow(int.Parse(NumberString));
            numberInputWindow.Owner = this;
            numberInputWindow.ShowDialog();

            bool isSave = numberInputWindow.DialogResult.HasValue && numberInputWindow.DialogResult.Value == true;
            if (isSave)
            {
                int enteredNumber = numberInputWindow.EnteredNumber;
                NumberString = enteredNumber.ToString();
            }
        }

    }
}
