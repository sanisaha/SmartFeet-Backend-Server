using Ecommerce.Domain.src.ProductAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.ProductSizeService
{
    public interface IProductSizeManagement : IBaseService<ProductSize, ProductSizeReadDto, ProductSizeCreateDto, ProductSizeUpdateDto>
    {
        Task<ProductSize> CreateAsync(ProductSizeCreateDto createDto);
        Task<bool> UpdateAsync(Guid id, ProductSizeUpdateDto updateDto);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<ProductSizeReadDto>> GetSizesByProductIdAsync(Guid productId);
    }
}