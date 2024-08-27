using Ecommerce.Domain.src.ProductAggregate;

namespace Ecommerce.Domain.src.Interface
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(Guid categoryId);
        Task<IEnumerable<Product>> SearchProductsByTitleAsync(string title);
        Task<IEnumerable<Product>> GetProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        Task<IEnumerable<Product>> GetTopSellingProductsAsync(int count);
        Task<IEnumerable<Product>> GetInStockProductsAsync();
    }
}