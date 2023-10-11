using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Models.Repositories.ProductRepository;

namespace RealEstateApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var value = await _productRepository.GetAllProductAsync();
        return Ok(value);
    }

    [HttpGet("ProductListWithCategory")]
    public async Task<IActionResult> ProductListWithCategory()
    {
        var value = await _productRepository.GetAllProductWithCategoryAsync();
        return Ok(value);
    }
}
