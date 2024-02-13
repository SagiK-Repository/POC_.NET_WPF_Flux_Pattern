using Fluxor;
using WPF_Fluxor_with_service.Action;
using WPF_Fluxor_with_service.Model.Count;

namespace WPF_Fluxor_with_service.Reducer;

public class CountReducer
{
    [ReducerMethod]
    public CountState ReduceIncreaseCounterAction(CountState state, IncreaseCounterAction action) =>
        new(number: state.Number + 1);

    [ReducerMethod(typeof(DecreaseCounterAction))]
    public CountState ReduceDecreaseCounterAction(CountState state) =>
        new(number: state.Number - 1);
}