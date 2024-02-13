using WPF_Fluxor_with_service.Model.Weather;

namespace WPF_Fluxor_with_service.Sevice;

public interface IWeatherService
{
    Task<Weather[]> GetRandomWeatherAsync(DateTime startDate);
}
