namespace WPF_Flux_INotifyPropertyChanged;

public interface IStore<T>
{
    T State { get; }
    void Dispatch(IFluxAction action);
}
