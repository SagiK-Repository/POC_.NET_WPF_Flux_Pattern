namespace WPF_Flux;

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
            Store.Instance.IncrementCounter();
        });
    }
}