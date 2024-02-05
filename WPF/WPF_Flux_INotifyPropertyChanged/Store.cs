using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_Flux_INotifyPropertyChanged;

public class Store<T> : IStore<T>, INotifyPropertyChanged
{
    private readonly Reducer<T> _reduce;
    private T _state;

    public Store(in T initialState, in Reducer<T> reducer)
    {
        _state = initialState;
        _reduce = reducer;
    }

    public T State
    {
        get { return _state; }
        private set
        {
            _state = value;
            OnPropertyChanged(nameof(State));
        }
    }

    public void Dispatch(IFluxAction action)
    {
        var newState = _reduce(State, action);
        if (EqualityComparer<T>.Default.Equals(newState, State)) return;
        State = newState;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}