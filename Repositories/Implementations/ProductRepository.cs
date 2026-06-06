using Microsoft.EntityFrameworkCore;
using MvcApi.Data;
using MvcApi.Models.Entities;
using MvcApi.Repositories.Interface;

namespace MvcApi.Repositories.Implementations
{
    public class ProductRepository(AppDbContext context) : IProductRepository
    {
       
        public async Task<Product> CreateProduct(Product product)
        {
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return product;

        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            var productId = await context.Products.FindAsync(id);
            if (productId is null)
            {
                return false;
            }

            context.Products.Remove(productId);
            await context.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await context.Products
            .AsNoTracking()
            .ToListAsync();
        }
    }
}
