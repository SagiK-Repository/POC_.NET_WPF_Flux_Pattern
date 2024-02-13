using Fluxor;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using WPF_Fluxor_with_service.Action;
using WPF_Fluxor_with_service.Model.Count;
using WPF_Fluxor_with_service.Model.Weather;

namespace WPF_Fluxor_with_service;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    private readonly IStore Store;
    public new readonly IDispatcher Dispatcher;
    public readonly IState<CountState> CountState;
    private readonly IState<WeatherState> WeatherState;

    public int Count { get; set; } = 0;
    public string LoadedStatus { get; set; } = "";
    public ObservableCollection<Weather> WeatherData { get; set; } = [];

    public MainWindow(IStore store, IDispatcher dispatcher, IState<CountState> counterState, IState<WeatherState> weatherState)
    {
        Store = store;
        Dispatcher = dispatcher;
        
        CountState = counterState;
        CountState.StateChanged += CounterState_StateChanged;

        WeatherState = weatherState;
        WeatherState.StateChanged += WeatherState_StateChanged;

        Store.InitializeAsync().Wait();

        InitializeComponent();

        DataContext = this;
    }

    #region StateChanged
    private void CounterState_StateChanged(object? sender, EventArgs e)
    {
        Count = CountState.Value.Number;
        OnPropertyChanged(nameof(Count));
    }

    private void WeatherState_StateChanged(object? sender, EventArgs e)
    {
        WeatherState changedData = WeatherState.Value;
        LoadedStatus = changedData.IsLoading == true ? "true" : "false";
        OnPropertyChanged(nameof(LoadedStatus));
        WeatherData = new ObservableCollection<Weather>(changedData.Forecasts);
        OnPropertyChanged(nameof(WeatherData));
    }
    #endregion

    #region Button_Click
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

    private void WeatherLoad_Click(object sender, RoutedEventArgs e)
    {
        var action = new FetchDataAction();
        Dispatcher.Dispatch(action);
    }
    #endregion

    #region PropertyChange
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion
}