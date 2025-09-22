using FluentValidation;
using FluentValidation.AspNetCore;
using InventorySystem.Application.DTOs;
using InventorySystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;
    private readonly IValidator<ProductCreateDto> _createValidator;
    private readonly IValidator<ProductUpdateDto> _updateValidator;

    public ProductsController(
        IProductService service,
        IValidator<ProductCreateDto> createValidator,
        IValidator<ProductUpdateDto> updateValidator)
    {
        _service = service;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll(CancellationToken ct)
        => Ok(await _service.GetAllAsync(ct));

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductDto>> GetById(int id, CancellationToken ct)
    {
        var product = await _service.GetByIdAsync(id, ct);
        return product is null ? NotFound() : Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> Create([FromBody] ProductCreateDto dto, CancellationToken ct)
    {
        var result = await _createValidator.ValidateAsync(dto, ct);
        if (!result.IsValid)
        {
            result.AddToModelState(ModelState, null);
            return ValidationProblem(ModelState);
        }

        var created = await _service.CreateAsync(dto, ct);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProductUpdateDto dto, CancellationToken ct)
    {
        if (id != dto.Id) return BadRequest("Route id and body id must match.");

        var result = await _updateValidator.ValidateAsync(dto, ct);
        if (!result.IsValid)
        {
            result.AddToModelState(ModelState, null);
            return ValidationProblem(ModelState);
        }

        await _service.UpdateAsync(dto, ct);
        return NoContent();
    }
}
