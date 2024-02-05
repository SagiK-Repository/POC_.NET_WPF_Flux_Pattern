using DevExpress.Mvvm.CodeGenerators;
using WPF_MVVM_DevExpress.Model;

namespace WPF_MVVM_DevExpress.ViewModels
{
    [GenerateViewModel]
    public partial class MainViewModel
    {
        [GenerateProperty]
        NumberModel _Model;

        public MainViewModel()
        {
            _Model = new NumberModel();
        }

        [GenerateCommand]
        void IncreseNumber() => _Model.IncrementNumber();
    }
}
