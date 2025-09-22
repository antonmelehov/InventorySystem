using Microsoft.Extensions.DependencyInjection;
using InventorySystem.Application.Interfaces;
using InventorySystem.Application.Services;


namespace InventorySystem.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        return services;
    }
}