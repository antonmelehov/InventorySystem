using FluentAssertions;
using InventorySystem.Domain.Entities;
using InventorySystem.Infrastructure.Data;
using InventorySystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Tests;

public class ProductRepositoryTests
{
    private static AppDbContext NewContext(string dbName)
    {
        var opts = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(dbName)
            .Options;
        return new AppDbContext(opts);
    }

    [Fact]
    public async Task Add_And_Get_Works()
    {
        var ctx = NewContext(nameof(Add_And_Get_Works));
        var repo = new ProductRepository(ctx);

        var created = await repo.AddAsync(new Product { Name="Pen", Description="Blue", Price=1.1m, Quantity=10 });
        created.Id.Should().BeGreaterThan(0);

        var fetched = await repo.GetByIdAsync(created.Id);
        fetched!.Name.Should().Be("Pen");
    }

    [Fact]
    public async Task Update_Works()
    {
        var ctx = NewContext(nameof(Update_Works));
        var repo = new ProductRepository(ctx);

        var p = await repo.AddAsync(new Product { Name="A", Description="", Price=1, Quantity=1 });
        p.Name = "B";
        await repo.UpdateAsync(p);

        var again = await repo.GetByIdAsync(p.Id);
        again!.Name.Should().Be("B");
    }
}