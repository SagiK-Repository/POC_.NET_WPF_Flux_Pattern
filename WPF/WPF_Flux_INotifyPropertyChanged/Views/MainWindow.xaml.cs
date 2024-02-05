using System.ComponentModel;
using System.Windows;
using WPF_Flux_INotifyPropertyChanged.Flux;

namespace WPF_Flux_INotifyPropertyChanged
{
    public partial class MainWindow : Window
    {

        private readonly Store<CounterState> _store;

        public MainWindow()
        {
            InitializeComponent();

            _store = new Store<CounterState>(new CounterState(), CounterReducer.Reduce);
            _store.PropertyChanged += OnStorePropertyChanged;

            Utilities.Dispatcher.Dispatch += action => action();
        }

        private void OnStorePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_store.State))
            {
                // UI 업데이트 로직 수행
                CounterLabel.Content = _store.State.Counter.ToString();
            }
        }

        private void IncrementButton_Click(object sender, RoutedEventArgs e)
        {
            ActionCreator.IncrementCounter();
        }
    }
}