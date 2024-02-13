using Fluxor;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WPF_Fluxor_with_service.Sevice;

namespace WPF_Fluxor_with_service
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection();
            services.AddScoped<MainWindow>();
            services.AddScoped<IWeatherService, WeatherService>();
            services.AddFluxor(o => o
                .ScanAssemblies(typeof(App).Assembly));

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            var mainView = serviceProvider.GetRequiredService<MainWindow>();
            mainView.Show();
        }
    }
}
