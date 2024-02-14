using Client.Domain.Count;
using DevExpress.Mvvm.CodeGenerators;
using Fluxor;

namespace Client.Business
{
    [GenerateViewModel]
    public partial class View2ViewModel
    {
        public readonly IState<CountState> CountState;

        [GenerateProperty]
        int _Count;

        public View2ViewModel(IState<CountState> counterState)
        {
            CountState = counterState;
            Count = CountState.Value.Number;
            CountState.StateChanged += (s, e) => Count = CountState.Value.Number;
        }
    }
}
