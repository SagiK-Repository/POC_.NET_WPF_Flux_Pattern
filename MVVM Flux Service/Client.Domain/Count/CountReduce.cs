using Client.Domain.Count.Action;
using Fluxor;

namespace Client.Domain.Count;

public class CountReducer
{
    [ReducerMethod]
    public CountState ReduceIncreaseCounterAction(CountState state, IncreseAction action) =>
        new(number: state.Number + 1);

    [ReducerMethod(typeof(DecreaseAction))]
    public CountState ReduceDecreaseCounterAction(CountState state) =>
        new(number: state.Number - 1);
}