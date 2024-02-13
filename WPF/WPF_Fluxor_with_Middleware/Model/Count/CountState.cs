﻿using Fluxor;

namespace WPF_Fluxor_with_Middleware.Model.Count;

[FeatureState]
public class CountState
{
    public int Number { get; }

    private CountState() { }

    public CountState(int number)
    {
        Number = number;
    }
}