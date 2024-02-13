using WPF_Fluxor_with_service.Model.Weather;

namespace WPF_Fluxor_with_service.Sevice;

public class WeatherService : IWeatherService
{
    private static readonly string[] Summaries =
    [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    public async Task<Weather[]> GetRandomWeatherAsync(DateTime startDate)
    {
        await Task.Delay(1000);
        var rng = new Random();
        return Enumerable.Range(1, 2).Select(index => new Weather
        {
            Date = startDate.AddDays(index),
            TemperatureC = rng.Next(-20, 55),
            Summary = Summaries[rng.Next(Summaries.Length)]
        }).ToArray();
    }
}
