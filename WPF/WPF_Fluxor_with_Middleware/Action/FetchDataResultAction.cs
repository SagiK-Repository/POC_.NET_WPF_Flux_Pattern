using WPF_Fluxor_with_Middleware.Model.Weather;

namespace WPF_Fluxor_with_Middleware.Action;

public class FetchDataResultAction
{
    public IEnumerable<Weather> Forecasts { get; }

    public FetchDataResultAction(IEnumerable<Weather> forecasts)
    {
        Forecasts = forecasts;
    }
}
