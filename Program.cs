using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//tinfo200:[2021-02-22-hufsar06-dykstra1] - Using statements allow access to subdirectories and allows asp.net to figure out what data it needs
using ContosoUniversity.Data;
using Microsoft.Extensions.DependencyInjection;

namespace ContosoUniversity
{
    public class Program
    {
        //tinfo200:[2021-02-22-hufsar06-dykstra1] - This is the main method - it inserts a call to a function that creates a database if one is not present
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            CreateDbIfNotExists(host);

            host.Run();
        }

        //tinfo200:[2021-02-22-hufsar06-dykstra1] - This method creates a database if one is not present
        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<SchoolContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
