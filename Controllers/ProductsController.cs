using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using MvcApi.Models.DTOs;
using MvcApi.Services.Interface;

namespace MvcApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[EnableRateLimiting("FixedWindowPolicy")]
public class ProductsController(IProductService productService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
    {
        var products = await productService.GetAllProductsAsync();
        return Ok(products);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> Create([FromBody] CreateProductDto createDto)
    {
        var result = await productService.CreateProduct(createDto);
        return CreatedAtAction(nameof(GetAll), new { id = result.Id }, result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await productService.DeleteProduct(id);
        return NoContent();
    }


}