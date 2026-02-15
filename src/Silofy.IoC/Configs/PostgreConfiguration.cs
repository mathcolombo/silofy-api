using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Silofy.Infra.Configs.Contexts;

namespace Silofy.IoC.Configs;

public static class PostgreConfiguration
{
    private const string ConnectionStringKeyNeon = "NeonConnection";
    
    public static IServiceCollection AddPostgreConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        AddNeon(services, configuration);
        return services;
    }                 

    private static void AddNeon(IServiceCollection services, IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString(ConnectionStringKeyNeon);
        services.AddDbContext<SilofyDbContext>(options =>
        {
            options.UseNpgsql(connectionString, b => b.MigrationsAssembly(typeof(SilofyDbContext).Assembly.FullName));
            options.EnableSensitiveDataLogging(); 
            options.LogTo(Console.WriteLine, LogLevel.Information);
        });
    }
}