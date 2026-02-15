using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Silofy.IoC.Configs;

namespace Silofy.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPostgreConfiguration(configuration);
        return services;
    }
}