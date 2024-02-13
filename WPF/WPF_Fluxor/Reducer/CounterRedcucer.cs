using Fluxor;
using WPF_Fluxor.Action;
using WPF_Fluxor.Model;

namespace WPF_Fluxor.Reducer;
public class CounterReducer
{
    [ReducerMethod]
    public CounterState ReduceIncreaseCounterAction(CounterState state, IncreaseCounterAction action) =>
        new(currentNumber: state.CurrentNumber + 1);

    [ReducerMethod]
    public CounterState ReduceDecreaseCounterAction(CounterState state, DecreaseCounterAction action) =>
        new(currentNumber: state.CurrentNumber - 1);

}