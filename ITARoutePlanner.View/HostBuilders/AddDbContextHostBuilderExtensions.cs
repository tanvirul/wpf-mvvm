using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ITARoutePlanner.EF;
using Microsoft.Extensions.DependencyInjection;

namespace ITARoutePlanner.View.HostBuilders
{
    public static class AddDbContextHostBuilderExtensions
    {
        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                string connectionString = context.Configuration.GetConnectionString("sqlite");
                Action<DbContextOptionsBuilder> configureDbContext = o => o.UseSqlite(connectionString);

                services.AddDbContext<ITARoutePlannerDbContext>(configureDbContext);
                services.AddSingleton<ITARoutePlannerDbContextFactory>(new ITARoutePlannerDbContextFactory(configureDbContext));
            });

            return host;
        }
    }
}
