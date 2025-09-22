using InventorySystem.Domain.Interfaces;
using InventorySystem.Infrastructure.Data;
using InventorySystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InventorySystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IConfiguration config)
    {
        var cs = config.GetConnectionString("DefaultConnection")
                 ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        services.AddDbContext<AppDbContext>(opt =>
            opt.UseMySql(cs, ServerVersion.AutoDetect(cs)));

        services.AddScoped<IProductRepository, ProductRepository>();
        return services;
    }
}