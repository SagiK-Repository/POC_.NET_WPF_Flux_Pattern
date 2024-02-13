using Fluxor;
using WPF_Fluxor_with_Middleware.Action;
using WPF_Fluxor_with_Middleware.Model.Count;

namespace WPF_Fluxor_with_Middleware.Reducer;

public class CountReducer
{
    [ReducerMethod]
    public CountState ReduceIncreaseCounterAction(CountState state, IncreaseCounterAction action) =>
        new(number: state.Number + 1);

    [ReducerMethod(typeof(DecreaseCounterAction))]
    public CountState ReduceDecreaseCounterAction(CountState state) =>
        new(number: state.Number - 1);
}