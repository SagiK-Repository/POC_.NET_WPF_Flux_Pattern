namespace WPF_Flux_INotifyPropertyChanged;

public interface IFluxAction
{
    ActionType Type { get; }
}