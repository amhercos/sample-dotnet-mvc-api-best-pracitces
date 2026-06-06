using MvcApi.Models.DTOs;
using MvcApi.Models.Entities;
using MvcApi.Repositories.Interface;
using MvcApi.Services.Interface;

namespace MvcApi.Services.Implementations
{
    public class ProductService(IProductRepository productRepository) : IProductService
    {
        public async Task<ProductDto> CreateProduct(CreateProductDto createDto)
        {
            if (createDto.Price < 0)
            {
                throw new ArgumentException("Product price cannot be negative.");
            }

            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = createDto.Name,
                Description = createDto.Description,
                Price = createDto.Price,
                CreatedAt = DateTime.UtcNow
            };

            var savedProduct = await productRepository.CreateProduct(product);

            return new ProductDto(
                savedProduct.Id,
                savedProduct.Name,
                savedProduct.Description,
                savedProduct.Price,
                savedProduct.CreatedAt
            );
        }

        public async Task<bool> DeleteProduct(Guid id)
        {

            var product = await productRepository.DeleteProduct(id);
            if (!product)
            {
                throw new KeyNotFoundException($"Product with ID {id} does not exist");
            }

            return true;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await productRepository.GetAllProductsAsync();
            return products.Select(p => new ProductDto(
                p.Id,
                p.Name,
                p.Description,
                p.Price,
                p.CreatedAt
                ));
        }
      
    }
}
