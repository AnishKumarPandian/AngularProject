using core.Entities;
using core.Interfaces;
using infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace infrastructure
{
    public class ProductRespository : IProductRepository
    {
        private readonly StoreContext _context;
        public  ProductRespository(StoreContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                        .Include(p => p.ProductBrand)
                        .Include(p => p.ProductType)
                        .FirstOrDefaultAsync(p=> p.Id == id);   
        }
        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products
                        .Include(p => p.ProductBrand)
                        .Include(p => p.ProductType)
                        .ToListAsync();
        }
        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }
        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }


    }
}