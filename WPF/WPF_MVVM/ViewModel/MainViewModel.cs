using System.ComponentModel;
using System.Windows.Input;
using WPF_MVVM.Model;
using WPF_MVVM.View;

namespace WPF_MVVM.ViewModel
{
    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private int _number;
        public int Number // { get;set; }
        {
            get { return _number; }
            set
            {
                _number = value;
                OnPropertyChanged(nameof(Number));
            }
        }
        private NumberModel Model { get; set; }
        public ICommand OpenNewWindowCommand { get; set; }

        public MainViewModel()
        {
            Model = new NumberModel();
            OpenNewWindowCommand = new RelayCommand((_) => OpenNewWindow());
        }

        private void OpenNewWindow()
        {
            SubViewModel subViewModel = new SubViewModel(Model);
            SubView newWindow = new SubView(subViewModel);
            newWindow.ShowDialog();

            Number = Model.InputNumber;

            // bool isSave = newWindow.DialogResult.HasValue && newWindow.DialogResult.Value == true;
            // if (isSave)
            // {
            //     Number = subViewModel..ToString();
            // }
        }
    }
}
