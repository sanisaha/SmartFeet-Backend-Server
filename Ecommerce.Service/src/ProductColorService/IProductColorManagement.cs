using Ecommerce.Domain.src.Entities.ProductAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.ProductColorService
{
    public interface IProductColorManagement : IBaseService<ProductColor, ProductColorReadDto, ProductColorCreateDto, ProductColorUpdateDto>
    {
        Task<ProductColor> CreateAsync(ProductColorCreateDto createDto);
        Task<bool> UpdateAsync(Guid id, ProductColorUpdateDto updateDto);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<ProductColorReadDto>> GetColorsByProductIdAsync(Guid productId);
        Task<ProductColorReadDto> GetColorByNameAsync(string colorName);

    }
}