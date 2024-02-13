using Fluxor;

namespace WPF_Fluxor.Model;

[FeatureState]
public class CounterState
{
    public int CurrentNumber { get; }

    private CounterState() { }

    public CounterState(int currentNumber)
    {
        CurrentNumber = currentNumber;
    }
}