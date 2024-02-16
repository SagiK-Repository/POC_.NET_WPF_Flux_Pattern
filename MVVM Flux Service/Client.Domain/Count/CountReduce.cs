using Client.Domain.Count.Action;
using Client.Domain.Service;
using Fluxor;

namespace Client.Domain.Count;

public class CountReducer
{
    private readonly ICountService CountService;

    public CountReducer(ICountService countService)
    {
        CountService = countService;
    }

    [ReducerMethod]
    public CountState ReduceIncreaseCounterAction(CountState state, IncreseAction action) =>
        new(number: state.Number + 1);

    [ReducerMethod(typeof(DecreaseAction))]
    public CountState ReduceDecreaseCounterAction(CountState state) =>
        new(number: CountService.Decrease(state.Number));
}