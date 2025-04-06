using Microsoft.Extensions.DependencyInjection;

namespace Razdor.Auth.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAuthServices(
        this IServiceCollection services
    ) {
        return services;
    }
}