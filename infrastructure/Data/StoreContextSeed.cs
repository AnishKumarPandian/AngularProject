using System.Text.Json;
using core.Entities;
using Microsoft.Extensions.Logging;

namespace infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext storeContext)
        {
            try
            {
                if(!storeContext.ProductBrands.Any())
                {
                    var branddata = File.ReadAllText("../infrastructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(branddata);

                    foreach(var item in brands){
                        storeContext.ProductBrands.Add(item);
                    }

                    await storeContext.SaveChangesAsync();
                }
                if(!storeContext.ProductTypes.Any())
                {
                    var brandtype = File.ReadAllText("../infrastructure/Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(brandtype);

                    foreach(var item in types){
                        storeContext.ProductTypes.Add(item);
                    }

                    await storeContext.SaveChangesAsync();
                }
                if(!storeContext.Products.Any())
                {
                    var products = File.ReadAllText("../infrastructure/Data/SeedData/products.json");
                    var product_list = JsonSerializer.Deserialize<List<Product>>(products);

                    foreach(var item in product_list){
                        storeContext.Products.Add(item);
                    }

                    await storeContext.SaveChangesAsync();
                }
            }
            catch(Exception ex){

            }
        }
    }
}