using System.ComponentModel;

public class NumberModel : INotifyPropertyChanged
{
    private int number;

    public int Number
    {
        get { return number; }
        set
        {
            number = value;
            OnPropertyChanged(nameof(Number));
        }
    }

    public void IncrementNumber()
    {
        Number++;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}