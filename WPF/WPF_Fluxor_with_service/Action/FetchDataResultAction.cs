using WPF_Fluxor_with_service.Model.Weather;

namespace WPF_Fluxor_with_service.Action;

public class FetchDataResultAction
{
    public IEnumerable<Weather> Forecasts { get; }

    public FetchDataResultAction(IEnumerable<Weather> forecasts)
    {
        Forecasts = forecasts;
    }
}
