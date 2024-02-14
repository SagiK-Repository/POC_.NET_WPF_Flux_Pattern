using Client.Business;
using Client.Domain.Interface.View;
using Client.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Client.Extensions;

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
        services.AddScoped<IView1Dialog, View1>();
        services.AddTransient<IView2Dialog, View2>();
        return services;
    }

    private static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        services.AddScoped<MainViewModel>();
        services.AddScoped<View1ViewModel>();
        services.AddScoped<View2ViewModel>();
        return services;
    }

}