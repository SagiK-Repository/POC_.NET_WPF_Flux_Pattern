using Fluxor;

namespace WPF_Fluxor_with_Middleware.Model.Weather;

[FeatureState]
public class WeatherState
{
    public bool IsLoading { get; }
    public IEnumerable<Weather> Forecasts { get; }

    private WeatherState() { }
    public WeatherState(bool isLoading, IEnumerable<Weather>? forecasts)
    {
        IsLoading = isLoading;
        Forecasts = forecasts ?? Array.Empty<Weather>();
    }
}