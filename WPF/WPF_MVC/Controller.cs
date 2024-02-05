using System.Windows.Input;

public class NumberController
{
    private NumberModel model;

    public NumberController(NumberModel model)
    {
        this.model = model;
    }

    public void Increment()
    {
        model.Number++;
    }
}