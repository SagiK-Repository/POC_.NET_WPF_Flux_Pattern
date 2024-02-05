namespace WPF_Flux;

public static class Dispatcher
{
    public static event Action<Action> Dispatch;

    public static void Invoke(Action action)
    {
        Dispatch?.Invoke(action);
    }
}