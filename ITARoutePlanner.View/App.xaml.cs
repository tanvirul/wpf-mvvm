using ITARoutePlanner.Domain.Models;
using ITARoutePlanner.EF;
using ITARoutePlanner.View.DataModel;
using ITARoutePlanner.View.HostBuilders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ITARoutePlanner.View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;
        public App()
        {
            _host = CreateHostBuilder().Build();
        }
        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder(args)
                .AddConfiguration()
                .AddDbContext()
                .AddServices()
                .AddStores()
                .AddViewModels()
                .AddViews();
        }
        protected async override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            ITARoutePlannerDbContextFactory contextFactory = _host.Services.GetRequiredService<ITARoutePlannerDbContextFactory>();
            using (ITARoutePlannerDbContext context = contextFactory.CreateDbContext())
            {
                var jsonData = JsonConvert.DeserializeObject<Data>(File.ReadAllText(@"data.json"));
                await context.Database.MigrateAsync();
            }
            await SeedDb();

            Window window = _host.Services.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }

        private async Task SeedDb()
        {
            ITARoutePlannerDbContextFactory contextFactory = _host.Services.GetRequiredService<ITARoutePlannerDbContextFactory>();
            using (ITARoutePlannerDbContext context = contextFactory.CreateDbContext())
            {
                var hasData = await context.Spacecrafts.AnyAsync();
                if (!hasData)
                {
                    var jsonData = JsonConvert.DeserializeObject<Data>(File.ReadAllText(@"data.json"));
                    await context.Planetes.AddRangeAsync(jsonData.Planets);
                    await context.Spacecrafts.AddRangeAsync(jsonData.Spacecrafts);
                    await context.SaveChangesAsync();
                }
            }
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }
    }
}
