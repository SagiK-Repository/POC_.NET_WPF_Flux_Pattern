namespace WPF_Flux_MVVM_DevExpress.Interface;
public interface IStore<T>
{
    T State { get; }
    void Dispatch(IFluxAction action);
}
