using System.ComponentModel;
using System.Runtime.CompilerServices;
using WPF_Flux_INotifyPropertyChanged.Interface;

namespace WPF_Flux_INotifyPropertyChanged.Flux;

public sealed class Store<T> : IStore<T>, INotifyPropertyChanged
{
    private readonly Reducer<T> _reduce;

    public Store(in T initialState, in Reducer<T> reducer)
    {
        State = initialState;
        _reduce = reducer;
    }

    public T State { get; private set; }

    public void Dispatch(IFluxAction action)
    {
        var newState = _reduce(State, action);
        if (EqualityComparer<T>.Default.Equals(newState, State)) return;
        State = newState;
        OnPropertyChanged(nameof(State));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}