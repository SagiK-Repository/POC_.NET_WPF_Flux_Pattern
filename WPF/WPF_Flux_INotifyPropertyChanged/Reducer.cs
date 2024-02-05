namespace WPF_Flux_INotifyPropertyChanged;

public delegate T Reducer<T>(T state, IFluxAction action);
