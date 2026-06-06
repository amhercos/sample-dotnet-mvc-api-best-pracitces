using MvcApi.Models.DTOs;
using MvcApi.Models.Entities;

namespace MvcApi.Services.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> CreateProduct(CreateProductDto createDto);
        Task<bool> DeleteProduct(Guid id);
    }
}
