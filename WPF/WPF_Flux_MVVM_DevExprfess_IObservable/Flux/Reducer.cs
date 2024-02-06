using WPF_Flux_MVVM_DevExpress_IObservable.Interface;

namespace WPF_Flux_MVVM_DevExpress_IObservable.Flux;

public delegate T Reducer<T>(T state, IFluxAction action);