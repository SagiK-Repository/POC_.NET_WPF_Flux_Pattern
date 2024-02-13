using BasicConcepts.MiddlewareTutorial.Store.Middlewares.Logging;
using Fluxor;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WPF_Fluxor_with_Middleware.Sevice;

namespace WPF_Fluxor_with_Middleware
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection();
            services.AddScoped<MainWindow>();
            services.AddScoped<IWeatherService, WeatherService>();
            services.AddFluxor(o => o
                .ScanAssemblies(typeof(App).Assembly)
                .AddMiddleware<LoggingMiddleware>());

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            var mainView = serviceProvider.GetRequiredService<MainWindow>();
            mainView.Show();
        }
    }
}
