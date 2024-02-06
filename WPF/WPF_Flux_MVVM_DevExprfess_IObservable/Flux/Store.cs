using DevExpress.Mvvm;
using System.Collections.Generic;
using WPF_Flux_MVVM_DevExpress_IObservable.Interface;
using System.Reactive.Subjects;
using System;

namespace WPF_Flux_MVVM_DevExpress_IObservable.Flux;

public sealed class Store<T> : ViewModelBase, IStore<T>
{
    private readonly Reducer<T> _reduce;
    private readonly BehaviorSubject<T> _stateSubject;

    public Store(in T initialState, in Reducer<T> reducer)
    {
        State = initialState;
        _reduce = reducer;
        _stateSubject = new BehaviorSubject<T>(initialState);
    }

    public T State
    {
        get { return _stateSubject.Value; }
        private set { SetProperty(() => State, value); }
    }

    public IObservable<T> StateObservable => _stateSubject;

    public void Dispatch(IFluxAction action)
    {
        var newState = _reduce(State, action);
        if (!EqualityComparer<T>.Default.Equals(newState, State))
        {
            State = newState;
            _stateSubject.OnNext(newState); // Observable을 업데이트합니다.
        }
    }
}