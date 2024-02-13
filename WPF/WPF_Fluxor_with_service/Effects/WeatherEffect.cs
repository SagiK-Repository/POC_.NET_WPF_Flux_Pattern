using Fluxor;
using WPF_Fluxor_with_service.Action;
using WPF_Fluxor_with_service.Sevice;

namespace WPF_Fluxor_with_service.Effects;

public class WeatherEffect
{
    private readonly IWeatherService WeatherForecastService;

    public WeatherEffect(IWeatherService weatherForecastService)
    {
        WeatherForecastService = weatherForecastService;
    }

    [EffectMethod]
    public async Task HandleFetchDataAction(FetchDataAction action, IDispatcher dispatcher)
    {
        var forecasts = await WeatherForecastService.GetRandomWeatherAsync(DateTime.Now);
        dispatcher.Dispatch(new FetchDataResultAction(forecasts));
    }
}
