using WPF_Flux_INotifyPropertyChanged.Utilities;

namespace WPF_Flux_INotifyPropertyChanged.Flux;
public enum ActionType
{
    IncrementCounter
}

public static class ActionCreator
{
    public static void IncrementCounter()
    {
        Dispatcher.Invoke(() =>
        {
            // 비즈니스 로직 수행
            Store<CounterState>.Instance.Dispatch(new FluxAction(ActionType.IncrementCounter));
        });
    }
}