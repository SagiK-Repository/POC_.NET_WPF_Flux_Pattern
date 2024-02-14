using Client.Domain.Count;
using DevExpress.Mvvm;
using DevExpress.Mvvm.CodeGenerators;
using Fluxor;

namespace Client.Business
{
    [GenerateViewModel]
    public partial class MainViewModel : ViewModelBase
    {
        private readonly IStore Store;
        public new readonly IDispatcher Dispatcher;
        public readonly IState<CountState> CountState;

        public int Count
        {
            get { return GetProperty(() => Count); }
            set { SetProperty(() => Count, value); }
        }

        public MainViewModel(IStore store, IDispatcher dispatcher, IState<CountState> counterState)
        {
            Store = store;
            Dispatcher = dispatcher;
            CountState = counterState;

            Initialize();
        }

        #region Initialize
        private void Initialize()
        {
            SetChangeEvent();
            Store.InitializeAsync().Wait();
        }

        private void SetChangeEvent()
        {
            CountState.StateChanged += CounterState_StateChanged;
        }
        #endregion

        private void CounterState_StateChanged(object? sender, EventArgs e)
        {
            Count = CountState.Value.Number;
        }

    }
}
