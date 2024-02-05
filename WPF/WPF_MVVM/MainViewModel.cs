using System.Windows.Input;

namespace WPF_MVVM;

class MainViewModel
{
    public NumberModel Model { get; set; }

    public ICommand IncreaseCommand { get; private set; }

    public MainViewModel()
    {
        Model = new NumberModel();
        IncreaseCommand = new RelayCommand(IncreaseNumber);
    }

    private void IncreaseNumber()
    {
        Model.IncrementNumber();
    }
}
