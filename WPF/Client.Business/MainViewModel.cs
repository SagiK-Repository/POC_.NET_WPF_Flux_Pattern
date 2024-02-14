using Client.Domain.Count;
using Client.Domain.Count.Action;
using DevExpress.Mvvm;
using DevExpress.Mvvm.CodeGenerators;
using Fluxor;

namespace Client.Business;

[GenerateViewModel]
public partial class MainViewModel : ViewModelBase
{
    private readonly IStore Store;
    public readonly IDispatcher Dispatcher;
    public readonly IState<CountState> CountState;

    [GenerateProperty]
    int _Count;

    public MainViewModel() { } // Xaml에서 조회하기 위해 필요

    public MainViewModel(IStore store, IDispatcher dispatcher, IState<CountState> counterState)
    {
        Store = store;
        Dispatcher = dispatcher;
        CountState = counterState;

        Initialize();
    }

    [GenerateCommand]
    void Increse() => Dispatcher.Dispatch(new IncreseAction());

    [GenerateCommand]
    void Decrease() => Dispatcher.Dispatch(new DecreaseAction());

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
