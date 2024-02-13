using Fluxor;
using WPF_Fluxor_with_Middleware.Action;
using WPF_Fluxor_with_Middleware.Model.Weather;

namespace WPF_Fluxor_with_Middleware.Reducer;

public static class Reducers
{
    [ReducerMethod(typeof(FetchDataAction))]
    public static WeatherState ReduceFetchDataAction(WeatherState state) =>
        new(isLoading: true, forecasts: null);

    [ReducerMethod]
    public static WeatherState ReduceFetchDataResultAction(WeatherState state, FetchDataResultAction action) =>
        new(isLoading: false, forecasts: action.Forecasts);
}