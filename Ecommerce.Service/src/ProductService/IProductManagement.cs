using Ecommerce.Domain.src.ProductAggregate;
using Ecommerce.Service.src.ProductSizeService;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.ProductService
{
    public interface IProductManagement : IBaseService<Product, ProductReadDto, ProductCreateDto, ProductUpdateDto>
    {
        Task<ProductCreateDto> CreateAsync(ProductCreateDto createDto);
        Task<ProductUpdateDto> UpdateAsync(Guid id, ProductUpdateDto updateDto);
        Task<ProductReadDto> GetByIdAsync(Guid id);
        Task DeleteAsync(Guid id);

    }
}