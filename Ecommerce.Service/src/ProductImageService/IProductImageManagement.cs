using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.src.ProductAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.ProductImageService
{
    public interface IProductImageManagement : IBaseService<ProductImage, ProductImageReadDto, ProductImageCreateDto, ProductImageUpdateDto>
    {
        Task<ProductImageCreateDto> CreateAsync(ProductImageCreateDto createDto);
        Task<ProductImageUpdateDto> UpdateAsync(Guid id, ProductImageUpdateDto updateDto);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<ProductImageReadDto>> GetImagesByProductIdAsync(Guid productId);
    }
}