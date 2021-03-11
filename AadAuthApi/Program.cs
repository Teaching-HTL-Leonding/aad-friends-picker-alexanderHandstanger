using AadAuthApi.model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AadAuthApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            //EntityFramework
            var factory = new FriendContextFactory();
            using var context = factory.CreateDbContext();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }


    class FriendContext : DbContext
    {
        public FriendContext(DbContextOptions<FriendContext> options)
            :base(options)
        { }
        public DbSet<Friend> Friends { get; set; }
    }

    class FriendContextFactory : IDesignTimeDbContextFactory<FriendContext>
    {
        public FriendContext CreateDbContext(string[]? args = null)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var optionsBuilder = new DbContextOptionsBuilder<FriendContext>();
            optionsBuilder
                // Uncomment the following line if you want to print generated
                // SQL statements on the console.
                // .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                .UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);

            return new FriendContext(optionsBuilder.Options);
        }
    }
}
