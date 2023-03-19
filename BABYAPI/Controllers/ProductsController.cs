using infrastructure.Data;
using core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using core.Interfaces;
using core.Specifications;

namespace BABYAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IGenericRepository<Product> _productrepo;
    private readonly IGenericRepository<ProductBrand> _productbrandrepo;
    private readonly IGenericRepository<ProductType> _producttyperepo;

    public ProductsController(IGenericRepository<Product> productrepo,
                              IGenericRepository<ProductBrand> productbrandrepo,
                              IGenericRepository<ProductType> producttyperepo)
    {
        _productrepo = productrepo;
        _productbrandrepo = productbrandrepo;
        _producttyperepo = producttyperepo;
    }
   

    [HttpGet("GetProducts")]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        var spec = new ProductsWithTypesAndBrandsSpecification();
        var product = await _productrepo.ListAllAsync(spec);
        return Ok(product);
    }

    [HttpGet("GetProduct")]
    public async Task<ActionResult<List<Product>>> GetProduct(int id)
    {
        var spec = new ProductsWithTypesAndBrandsSpecification(id);
        return Ok(await _productrepo.GetEntityWithSpec(spec));
    }

    [HttpGet("GetProductBrands")]
    public async Task<ActionResult<List<Product>>> GetProductBrands()
    {
        var productbrands = await _productbrandrepo.ListAllAsync();
        return Ok(productbrands);
    }

    [HttpGet("GetProductTypes")]
    public async Task<ActionResult<List<Product>>> GetProductTypes()
    {
        var producttypes = await _producttyperepo.ListAllAsync();
        return Ok(producttypes);
    }
}
