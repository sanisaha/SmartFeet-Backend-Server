namespace Ecommerce.Domain.src.Interface
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        IEnumerable<Product> GetProductsByCategory(Guid categoryId);
        IEnumerable<Product> SearchProductsByTitle(string title);
        IEnumerable<Product> GetProductsByPriceRange(decimal minPrice, decimal maxPrice);
        IEnumerable<Product> GetTopSellingProducts(int count);
        IEnumerable<Product> GetInStockProducts();
    }
}