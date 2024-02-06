using WPF_MVVM_Flux_INotifyPropertyChanged.Interface;

namespace WPF_MVVM_Flux_INotifyPropertyChanged.Flux;

public delegate T Reducer<T>(T state, IFluxAction action);