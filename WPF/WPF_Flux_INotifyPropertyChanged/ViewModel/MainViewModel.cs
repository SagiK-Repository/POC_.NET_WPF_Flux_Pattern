using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WPF_MVVM_Flux_INotifyPropertyChanged.Flux;
using WPF_MVVM_Flux_INotifyPropertyChanged.Interface;

namespace WPF_MVVM_Flux_INotifyPropertyChanged.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly Store<int> _counterStore;

        public MainViewModel()
        {
            _counterStore = new Store<int>(0, CounterReducer);
            _counterStore.PropertyChanged += (sender, args) => OnPropertyChanged(nameof(CounterValue));
        }

        public int CounterValue => _counterStore.State;

        public ICommand IncrementCommand => new RelayCommand(Increment);

        private void Increment()
        {
            _counterStore.Dispatch(new IncrementAction());
        }

        private int CounterReducer(int state, IFluxAction action)
        {
            if (action is IncrementAction)
            {
                return state + 1;
            }

            return state;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}