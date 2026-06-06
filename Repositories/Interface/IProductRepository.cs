using MvcApi.Models.Entities;

namespace MvcApi.Repositories.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> CreateProduct(Product product);
        Task<bool> DeleteProduct(Guid id);
    }
}
