namespace WPF_MVVM
{
    public interface IDialogView
    {
        bool? ShowDialog();

        bool? DialogResult { get; set; }

        void Show();

        void Close();
    }
}
