using Fluxor;
using WPF_Fluxor.Action;

namespace WPF_Fluxor.Effect;

public class Effect
{
    // [EffectMethod]
    // public async Task HandleFetchDataAction(DecreaseCounterAction action, IDispatcher dispatcher)
    // {
    //     dispatcher.Dispatch(new ShowDialogAction("Effect", "Hello"));
    // }

    [EffectMethod(typeof(DecreaseCounterAction))]
    public async Task HandleFetchDataAction(IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new ShowDialogAction("Effect", "Hello"));
    }
}
