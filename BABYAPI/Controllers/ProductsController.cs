using infrastructure.Data;
using core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using core.Interfaces;

namespace BABYAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _repo;

    public ProductsController(IProductRepository repo)
    {
        _repo = repo;
    }
   

    [HttpGet("GetProducts")]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        var product = await _repo.GetProductsAsync();
        return Ok(product);
    }

    [HttpGet("GetProduct")]
    public async Task<ActionResult<List<Product>>> GetProduct(int id)
    {

        return Ok(await _repo.GetProductByIdAsync(id));
    }

    [HttpGet("GetProductBrands")]
    public async Task<ActionResult<List<Product>>> GetProductBrands()
    {
        var productbrands = await _repo.GetProductBrandsAsync();
        return Ok(productbrands);
    }

    [HttpGet("GetProductTypes")]
    public async Task<ActionResult<List<Product>>> GetProductTypes()
    {
        var producttypes = await _repo.GetProductTypesAsync();
        return Ok(producttypes);
    }
}
