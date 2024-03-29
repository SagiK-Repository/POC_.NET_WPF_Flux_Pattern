﻿using DevExpress.Mvvm;
using System.Collections.Generic;
using WPF_Flux_MVVM_DevExpress.Interface;

namespace WPF_Flux_MVVM_DevExpress.Flux;

public sealed class Store<T> : ViewModelBase, IStore<T>
{
    private readonly Reducer<T> _reduce;

    public Store(in T initialState, in Reducer<T> reducer)
    {
        State = initialState;
        _reduce = reducer;
    }

    public T State
    {
        get { return GetProperty(() => State); }
        private set { SetProperty(() => State, value); }
    }

    public void Dispatch(IFluxAction action)
    {
        var newState = _reduce(State, action);
        if (EqualityComparer<T>.Default.Equals(newState, State)) return;
        State = newState;
    }
}