using Ecommerce.Domain.src.Entities.ProductAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.ProductColorService
{
    public interface IProductColorManagement : IBaseService<ProductColor, ProductColorReadDto, ProductColorCreateDto, ProductColorUpdateDto>
    {
        Task<ProductColorCreateDto> CreateAsync(ProductColorCreateDto createDto);
        Task<ProductColorUpdateDto> UpdateAsync(Guid id, ProductColorUpdateDto updateDto);
        public Task DeleteAsync(Guid id);
        Task<IEnumerable<ProductColorReadDto>> GetColorsByProductIdAsync(Guid productId);
        Task<ProductColorReadDto> GetColorByNameAsync(string colorName);

    }
}