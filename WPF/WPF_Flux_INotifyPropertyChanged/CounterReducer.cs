namespace WPF_Flux_INotifyPropertyChanged;

public static class CounterReducer
{
    public static CounterState Reduce(CounterState state, IFluxAction action)
    {
        switch (action.Type)
        {
            case ActionType.IncrementCounter:
                return new CounterState { Counter = state.Counter + 1 };
            default:
                return state;
        }
    }
}