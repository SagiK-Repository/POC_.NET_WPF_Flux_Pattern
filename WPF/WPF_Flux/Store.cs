namespace WPF_Flux;

public class Store
{
    private int _counter;

    public int Counter
    {
        get { return _counter; }
        private set
        {
            _counter = value;
            CounterChanged?.Invoke(_counter);
        }
    }

    public static Store Instance { get; } = new Store();

    public event Action<int> CounterChanged;

    public void IncrementCounter() => Counter++;
}