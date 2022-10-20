using ITARoutePlanner.Domain.Models;
using ITARoutePlanner.Domain.Models.Services;
using ITARoutePlanner.EF.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITARoutePlanner.View.HostBuilders
{
    public static class AddServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<IDataService<Spacecraft>, SpacecraftService>();
                services.AddSingleton<ISpacecraftService, SpacecraftService>();
               
            });

            return host;
        }
    }
}
