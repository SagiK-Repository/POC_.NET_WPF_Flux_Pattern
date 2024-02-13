using Fluxor;
using System.ComponentModel;
using System.Windows;
using WPF_Fluxor.Action;
using WPF_Fluxor.Model;

namespace WPF_Fluxor;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    private readonly IStore Store;
    public readonly IDispatcher Dispatcher;
    public readonly IState<CounterState> CounterState;

    public int Count { get; set; }

    public MainWindow(IStore store, IDispatcher dispatcher, IState<CounterState> counterState)
    {
        Store = store;
        Dispatcher = dispatcher;
        CounterState = counterState;
        CounterState.StateChanged += CounterState_StateChanged;

        Store.InitializeAsync().Wait();

        InitializeComponent();
     
        Count = 0;
        DataContext = this;
    }

    private void CounterState_StateChanged(object sender, EventArgs e)
    {
        Count = CounterState.Value.CurrentNumber;
        OnPropertyChanged(nameof(Count));
    }

    private void IncreaseButton_Click(object sender, RoutedEventArgs e)
    {
        var action = new IncreaseCounterAction();
        Dispatcher.Dispatch(action);
    }

    private void DecreaseButton_Click(object sender, RoutedEventArgs e)
    {
        var action = new DecreaseCounterAction();
        Dispatcher.Dispatch(action);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}