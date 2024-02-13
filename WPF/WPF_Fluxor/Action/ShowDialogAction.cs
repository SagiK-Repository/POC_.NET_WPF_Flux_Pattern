namespace WPF_Fluxor.Action;

public class ShowDialogAction 
{
    public string Title { get; }
    public string Message { get; }
    public ShowDialogAction(string title, string message)
    {
        Title = title;
        Message = message;
    }
}
