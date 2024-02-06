namespace WPF_MVVM_Flux_INotifyPropertyChanged.Interface;

public interface IStore<T>
{
    T State { get; }
    void Dispatch(IFluxAction action);
}
