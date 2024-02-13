using WPF_Fluxor_with_Middleware.Model.Weather;

namespace WPF_Fluxor_with_Middleware.Sevice;

public interface IWeatherService
{
    Task<Weather[]> GetRandomWeatherAsync(DateTime startDate);
}
