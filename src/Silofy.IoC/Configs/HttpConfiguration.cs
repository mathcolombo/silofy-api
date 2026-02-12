using Microsoft.Extensions.DependencyInjection;

namespace Silofy.IoC.Configs;

public static class HttpConfiguration
{
    public static IServiceCollection AddHttpConfiguration(this IServiceCollection services)
    {
        return services;
    }
}