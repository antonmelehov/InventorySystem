using InventorySystem.Domain.Entities;
using InventorySystem.Domain.Interfaces;
using InventorySystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _db;

    public ProductRepository(AppDbContext db) => _db = db;

    public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken ct = default)
        => await _db.Products.AsNoTracking().ToListAsync(ct);

    public Task<Product?> GetByIdAsync(int id, CancellationToken ct = default)
        => _db.Products.FindAsync(new object[] { id }, ct).AsTask();

    public async Task<Product> AddAsync(Product product, CancellationToken ct = default)
    {
        _db.Products.Add(product);
        await _db.SaveChangesAsync(ct);
        return product;
    }

    public async Task UpdateAsync(Product product, CancellationToken ct = default)
    {
        _db.Entry(product).State = EntityState.Modified;
        await _db.SaveChangesAsync(ct);
    }
}