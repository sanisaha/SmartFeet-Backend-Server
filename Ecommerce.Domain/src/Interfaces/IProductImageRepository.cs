using Ecommerce.Domain.src.ProductAggregate;

namespace Ecommerce.Domain.src.Interface.ProductInterface
{
    public interface IProductImageRepository : IBaseRepository<ProductImage>
    {
        Task<IEnumerable<ProductImage>> GetImagesByProductIdAsync(Guid productId);
        Task<ProductImage> GetMainImageForProductAsync(Guid productId);
        Task<int> GetImageCountByProductIdAsync(Guid productId);
        Task<bool> DeleteImagesByProductIdAsync(Guid productId);
    }
}