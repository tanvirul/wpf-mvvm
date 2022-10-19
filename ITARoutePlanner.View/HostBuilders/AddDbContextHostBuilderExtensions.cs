using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                //services.AddDbContext<SimpleTraderDbContext>(configureDbContext);
                //services.AddSingleton<SimpleTraderDbContextFactory>(new SimpleTraderDbContextFactory(configureDbContext));
            });

            return host;
        }
    }
}
