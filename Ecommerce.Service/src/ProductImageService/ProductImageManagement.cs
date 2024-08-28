using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.src.ProductAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.ProductImageService
{
    public class ProductImageManagement : BaseService<ProductImage, ProductImageReadDto, ProductImageCreateDto, ProductImageUpdateDto>, IProductImageManagement
    {
        public async Task<ProductImageCreateDto> CreateAsync(ProductImageCreateDto createDto)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductImageReadDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductImageReadDto>> GetImagesByProductIdAsync(Guid productId)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductImageUpdateDto> UpdateAsync(Guid id, ProductImageUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}