using Fluxor;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace WPF_Fluxor;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        var services = new ServiceCollection();
        services.AddScoped<MainWindow>();
        services.AddFluxor(o => o
            .ScanAssemblies(typeof(App).Assembly));

        IServiceProvider serviceProvider = services.BuildServiceProvider();

        var mainView = serviceProvider.GetRequiredService<MainWindow>();
        mainView.Show();
    }
}
