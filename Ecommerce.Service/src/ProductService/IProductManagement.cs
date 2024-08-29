using Ecommerce.Domain.src.ProductAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.ProductService
{
    public interface IProductManagement : IBaseService<Product, ProductReadDto, ProductCreateDto, ProductUpdateDto>
    {
        Task<Product> CreateAsync(ProductCreateDto productCreateDto);
        Task<bool> UpdateAsync(Guid productId, ProductUpdateDto productUpdateDto);
        Task<bool> DeleteAsync(Guid productId);
        Task<ProductReadDto> GetByIdAsync(Guid productId);
        Task<IEnumerable<ProductReadDto>> GetProductsByCategoryAsync(Guid categoryId);
        Task<IEnumerable<ProductReadDto>> SearchProductsByTitleAsync(string title);
        Task<IEnumerable<ProductReadDto>> GetProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        Task<IEnumerable<ProductReadDto>> GetTopSellingProductsAsync(int count);
        Task<IEnumerable<Product>> GetInStockProductsAsync();

    }
}