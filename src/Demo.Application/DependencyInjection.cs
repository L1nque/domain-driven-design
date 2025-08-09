using Microsoft.Extensions.DependencyInjection;

namespace Demo.Application.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureApplication<TAssemblyMarker>(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblyContaining<TAssemblyMarker>();
        });

        return services;
    }
}
