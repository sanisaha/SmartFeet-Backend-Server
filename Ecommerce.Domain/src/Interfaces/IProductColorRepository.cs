using Ecommerce.Domain.src.Entities.ProductAggregate;

namespace Ecommerce.Domain.src.Interface.ProductInterface
{
    public interface IProductColorRepository : IBaseRepository<ProductColor>
    {
        Task<IEnumerable<ProductColor>> GetColorsByProductIdAsync(Guid productId);
        Task<ProductColor> GetColorByNameAsync(string colorName);
    }
}