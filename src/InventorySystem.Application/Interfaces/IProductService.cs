using InventorySystem.Application.DTOs;

namespace InventorySystem.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllAsync(CancellationToken ct = default);
    Task<ProductDto?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<ProductDto> CreateAsync(ProductCreateDto dto, CancellationToken ct = default);
    Task UpdateAsync(ProductUpdateDto dto, CancellationToken ct = default);
}