namespace InventorySystem.Application.DTOs;

public record ProductDto(int Id, string Name, string Description, decimal Price, int Quantity);

public interface IProductWriteModel
{
    string Name { get; }
    string Description { get; }
    decimal Price { get; }
    int Quantity { get; }
}

public record ProductCreateDto(string Name, string Description, decimal Price, int Quantity)
    : IProductWriteModel;

public record ProductUpdateDto(int Id, string Name, string Description, decimal Price, int Quantity)
    : IProductWriteModel;