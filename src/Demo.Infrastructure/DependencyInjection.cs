using Demo.Application.FleetManagement.Services;
using Demo.Application.RentalContracting.Interfaces;
using Demo.Infrastructure.Adapters;
using Demo.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddEfCore();
        services.ConfigureAdapters();

        return services;
    }

    private static IServiceCollection AddEfCore(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql("Host=localhost;Port=5432;Database=mydb;Username=postgres;Password=postgres");
        });

        return services;
    }

    private static IServiceCollection ConfigureAdapters(this IServiceCollection services)
    {
        services.AddScoped<IFleetAdapter, FleetAdapter>();
        services.AddScoped<IDriverAdapter, DriverAdapter>();
        services.AddScoped<IBillingAdapter, BillingAdapter>();
        services.AddScoped<IInsuranceComplianceAdapter, InsuranceAdapter>();
        return services;
    }
}