using infrastructure.Data;
using core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BABYAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly StoreContext _context;
    public ProductsController(StoreContext context)
    {
        _context = context;
    }
    [HttpGet("GetProducts")]
    public ActionResult<List<Product>> GetProducts()
    {
        return Ok(_context.Products.ToList());
    }

    [HttpGet("GetAsyncProducts")]
    public async Task<ActionResult<List<Product>>> GetAsyncProducts()
    {
        var product = await _context.Products.ToListAsync();
        return Ok(product);
    }

    [HttpGet("GetProduct")]
    public async Task<ActionResult<List<Product>>> GetProduct(int id)
    {

        return Ok(await _context.Products.FindAsync(id));
    }
}
