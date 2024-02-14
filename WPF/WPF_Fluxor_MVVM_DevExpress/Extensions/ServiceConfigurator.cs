using Microsoft.Extensions.DependencyInjection;
using WPF_Fluxor_MVVM_DevExpress.ViewModels;

namespace WPF_Fluxor_MVVM_DevExpress.Extensions;

public static class ServiceConfigurator
{
    public static IServiceCollection Configure(this IServiceCollection services)
    {
        services.AddWpfUI();
        services.AddViews();
        services.AddViewModels();

        return services;
    }

    private static IServiceCollection AddWpfUI(this IServiceCollection services)
    {
        return services;
    }

    private static IServiceCollection AddViews(this IServiceCollection services)
    {
        services.AddScoped<MainWindow>();
        return services;
    }

    private static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        services.AddScoped<MainViewModel>();
        return services;
    }

}