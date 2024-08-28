using Ecommerce.Domain.src.ProductAggregate;

namespace Ecommerce.Domain.src.Interface.ProductInterface
{
    public interface IProductSizeRepository : IBaseRepository<ProductSize>
    {
        Task<IEnumerable<ProductSize>> GetSizesByProductIdAsync(Guid productId);
        Task<ProductSize> GetSizeByNameAsync(string sizeName);
    }
}