﻿using WPF_Flux_INotifyPropertyChanged.Interface;

namespace WPF_Flux_INotifyPropertyChanged.Flux;

public delegate T Reducer<T>(T state, IFluxAction action);