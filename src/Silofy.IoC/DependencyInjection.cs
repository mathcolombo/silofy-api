using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Silofy.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, string? connectionString)
    {
        //services.AddDbContext<SilofyDbContext>(options => options.UseNpgsql(connectionString, b => b.MigrationsAssembly(typeof(SilofyDbContext).Assembly.FullName))); 

        return services;
    }
}