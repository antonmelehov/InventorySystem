using InventorySystem.Application.DTOs;
using InventorySystem.Application.Interfaces;
using InventorySystem.Domain.Entities;
using InventorySystem.Domain.Interfaces;

namespace InventorySystem.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repo;

    public ProductService(IProductRepository repo) => _repo = repo;

    public async Task<IEnumerable<ProductDto>> GetAllAsync(CancellationToken ct = default)
        => (await _repo.GetAllAsync(ct))
            .Select(p => new ProductDto(p.Id, p.Name, p.Description, p.Price, p.Quantity));

    public async Task<ProductDto?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        var p = await _repo.GetByIdAsync(id, ct);
        return p is null ? null : new ProductDto(p.Id, p.Name, p.Description, p.Price, p.Quantity);
    }

    public async Task<ProductDto> CreateAsync(ProductCreateDto dto, CancellationToken ct = default)
    {
        var entity = new Product
        {
            Name = dto.Name.Trim(),
            Description = dto.Description?.Trim() ?? "",
            Price = dto.Price,
            Quantity = dto.Quantity
        };

        var created = await _repo.AddAsync(entity, ct);
        return new ProductDto(created.Id, created.Name, created.Description, created.Price, created.Quantity);
    }

    public async Task UpdateAsync(ProductUpdateDto dto, CancellationToken ct = default)
    {
        var entity = new Product
        {
            Id = dto.Id,
            Name = dto.Name.Trim(),
            Description = dto.Description?.Trim() ?? "",
            Price = dto.Price,
            Quantity = dto.Quantity
        };

        await _repo.UpdateAsync(entity, ct);
    }
}