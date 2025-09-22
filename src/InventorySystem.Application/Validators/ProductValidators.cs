using FluentValidation;
using InventorySystem.Application.DTOs;

namespace InventorySystem.Application.Validators;

public class ProductWriteValidator<T> : AbstractValidator<T> where T : IProductWriteModel
{
    public ProductWriteValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Description).MaximumLength(2000);
        RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0);
    }
}

public class ProductCreateValidator : AbstractValidator<ProductCreateDto>
{
    public ProductCreateValidator()
    {
        Include(new ProductWriteValidator<ProductCreateDto>());
    }
}

public class ProductUpdateValidator : AbstractValidator<ProductUpdateDto>
{
    public ProductUpdateValidator()
    {
        Include(new ProductWriteValidator<ProductUpdateDto>());
        RuleFor(x => x.Id).GreaterThan(0);
    }
}