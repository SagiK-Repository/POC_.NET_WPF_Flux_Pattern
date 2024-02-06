using DevExpress.Mvvm;
using DevExpress.Mvvm.CodeGenerators;
using WPF_Flux_MVVM_DevExpress.Flux;
using WPF_Flux_MVVM_DevExpress.Interface;

namespace WPF_Flux_MVVM_DevExpress.ViewModels
{
    [GenerateViewModel]
    public partial class MainViewModel : ViewModelBase
    {
        private readonly Store<int> _counterStore;

        public MainViewModel()
        {
            _counterStore = new Store<int>(0, CounterReducer);
            _counterStore.PropertyChanged += (sender, args) => RaisePropertyChanged(nameof(CounterValue));
        }

        public int CounterValue => _counterStore.State;

        [GenerateCommand]
        public void Increment()
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
    }
}
