using ITARoutePlanner.View.ViewModels;
using ITARoutePlanner.View.ViewModels.Factories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITARoutePlanner.View.HostBuilders
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddTransient<SpacecraftViewModel>();
                services.AddTransient<MainViewModel>();

                services.AddSingleton<CreateViewModel<SpacecraftViewModel>>(services => () => services.GetRequiredService<SpacecraftViewModel>());
                services.AddSingleton<IRoutePlannerViewModelFactory, RoutePlannerViewModelFactory>();

            });

            return host;
        }

    }
}
