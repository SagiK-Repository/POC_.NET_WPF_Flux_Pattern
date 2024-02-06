using WPF_Flux_MVVM_DevExpress.Interface;

namespace WPF_Flux_MVVM_DevExpress.Flux;

public delegate T Reducer<T>(T state, IFluxAction action);