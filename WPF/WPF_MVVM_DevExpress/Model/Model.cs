using DevExpress.Mvvm;

namespace WPF_MVVM_DevExpress.Model;

public class NumberModel : ViewModelBase
{
    public int Number
    {
        get { return GetProperty(() => Number); }
        set { SetProperty(() => Number, value); }
    }
    public void IncrementNumber()
    {
        Number++;
    }
}
