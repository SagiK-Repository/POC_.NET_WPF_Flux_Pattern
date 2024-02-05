namespace WPF_Flux_INotifyPropertyChanged.Flux;

public class FluxAction : IFluxAction
{
    public ActionType Type { get; }

    public FluxAction(ActionType type)
    {
        Type = type;
    }
}