using FluentAssertions;
using InventorySystem.Application.DTOs;
using InventorySystem.Application.Validators;

namespace InventorySystem.Tests;

public class ProductValidatorsTests
{
    [Fact]
    public void Create_Should_Fail_When_Name_Empty()
    {
        var v = new ProductCreateValidator();
        var result = v.Validate(new ProductCreateDto("", "x", 1, 1));
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "Name");
    }

    [Fact]
    public void Update_Should_Fail_When_Id_Invalid()
    {
        var v = new ProductUpdateValidator();
        var result = v.Validate(new ProductUpdateDto(0, "Ok", "x", 1, 1));
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "Id");
    }
}