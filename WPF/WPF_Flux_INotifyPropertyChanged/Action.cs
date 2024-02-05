namespace WPF_Flux_INotifyPropertyChanged;
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
            Store.Instance.Dispatch(new FluxAction(ActionType.IncrementCounter));
        });
    }
}