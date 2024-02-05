namespace WPF_Flux_INotifyPropertyChanged.Flux;

public interface IStore<T>
{
    T State { get; }
    void Dispatch(IFluxAction action);
}
