using System.Windows;

namespace WPF_Flux
{
    public partial class MainWindow : Window
    {
        private readonly Store _store;

        public MainWindow()
        {
            InitializeComponent();

            _store = Store.Instance;
            _store.CounterChanged += OnCounterChanged;

            WPF_Flux.Dispatcher.Dispatch += action => action();
        }

        private void OnCounterChanged(int counter)
        {
            // UI 업데이트 로직 수행
            CounterLabel.Content = counter.ToString();
        }

        private void IncrementButton_Click(object sender, RoutedEventArgs e)
        {
            ActionCreator.IncrementCounter();
        }
    }
}