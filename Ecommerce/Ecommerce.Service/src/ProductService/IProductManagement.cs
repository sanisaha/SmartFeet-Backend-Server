using Ecommerce.Domain.src.Model;
using Ecommerce.Domain.src.ProductAggregate;
using Ecommerce.Domain.src.Shared;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.ProductService
{
    public interface IProductManagement : IBaseService<Product, ProductReadDto, ProductCreateDto, ProductUpdateDto>
    {
        Task<IEnumerable<ProductReadDto>> GetProductsByCategoryAsync(Guid categoryId);
        Task<IEnumerable<ProductReadDto>> SearchProductsByTitleAsync(string title);
        Task<IEnumerable<ProductReadDto>> GetProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        Task<IEnumerable<ProductReadDto>> GetTopSellingProductsAsync(int count);
        Task<IEnumerable<Product>> GetInStockProductsAsync();
        Task<PaginatedResult<ProductReadDto>> GetFilteredProductsAsync(PaginationOptions paginationOptions, FilterOptions filterOptions);
        Task<IEnumerable<ProductReadDto>> GetProductsBySubcategoryAsync(Guid subcategoryId);
        Task<IEnumerable<ProductReadDto>> GetProductsByNewArrivalAsync();
        Task<IEnumerable<ProductReadDto>> GetProductsByFeaturedAsync();

    }
}