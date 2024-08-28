using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.src.ProductAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.ProductSizeService
{
    public interface IProductSizeManagement : IBaseService<ProductSize, ProductSizeReadDto, ProductSizeCreateDto, ProductSizeUpdateDto>
    {
        Task<ProductSizeCreateDto> CreateAsync(ProductSizeCreateDto createDto);
        Task<ProductSizeUpdateDto> UpdateAsync(Guid id, ProductSizeUpdateDto updateDto);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<ProductSizeReadDto>> GetSizesByProductIdAsync(Guid productId);
    }
}