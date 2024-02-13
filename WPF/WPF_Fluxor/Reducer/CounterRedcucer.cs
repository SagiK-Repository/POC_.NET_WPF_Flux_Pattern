using Fluxor;
using System.Windows;
using WPF_Fluxor.Action;
using WPF_Fluxor.Model;

namespace WPF_Fluxor.Reducer;
public class CounterReducer
{
    [ReducerMethod]
    public CounterState ReduceIncreaseCounterAction(CounterState state, IncreaseCounterAction action) =>
        new(currentNumber: state.CurrentNumber + 1);

    [ReducerMethod(typeof(DecreaseCounterAction))]
    public CounterState ReduceDecreaseCounterAction(CounterState state) =>
        new(currentNumber: state.CurrentNumber - 1);

    [ReducerMethod]
    public CounterState ReduceShowDialogAction(CounterState state, ShowDialogAction action)
    {
        MessageBox.Show(action.Title, action.Message);
        return state; // 원하는 변화를 줄 수 있다.
    }
}