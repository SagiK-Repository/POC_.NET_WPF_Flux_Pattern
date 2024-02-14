using Fluxor;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using WPF_Fluxor_MVVM_DevExpress.Extensions;

namespace WPF_Fluxor_MVVM_DevExpress
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection();
            services.Configure();
            services.AddFluxor(o => o
                .ScanAssemblies(typeof(App).Assembly));

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            var mainView = serviceProvider.GetRequiredService<MainWindow>();
            mainView.Show();
        }
    }
}
