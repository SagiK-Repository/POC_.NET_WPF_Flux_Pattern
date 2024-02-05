namespace WPF_Flux_INotifyPropertyChanged.Flux;

public interface IFluxAction
{
    ActionType Type { get; }
}