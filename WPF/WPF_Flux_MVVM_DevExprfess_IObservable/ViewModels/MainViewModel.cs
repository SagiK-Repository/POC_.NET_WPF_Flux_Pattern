using DevExpress.Mvvm;
using DevExpress.Mvvm.CodeGenerators;
using WPF_Flux_MVVM_DevExpress_IObservable.Flux;
using WPF_Flux_MVVM_DevExpress_IObservable.Interface;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace WPF_Flux_MVVM_DevExpress_IObservable.ViewModels
{
    [GenerateViewModel]
    public partial class MainViewModel : ViewModelBase
    {
        private readonly Store<int> _counterStore;

        public MainViewModel()
        {
            _counterStore = new Store<int>(0, CounterReducer);

            _counterStore.StateObservable
                .ObserveOnDispatcher()
                .Subscribe(state => RaisePropertyChanged(nameof(CounterValue)));
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
