using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace SoLivros.API
{
    using SoLivros.DataAccess.EF;
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var annotPadContext = services.GetService<SoLivrosContext>();
                annotPadContext.Database.SetCommandTimeout((int)TimeSpan.FromMinutes(30).TotalSeconds);

                await annotPadContext.Database.MigrateAsync();
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls("https://*:5001", "https://localhost:5001", "http://*:5000", "http://localhost:5000");
                    webBuilder.UseStartup<Startup>();
                });
    }
}
