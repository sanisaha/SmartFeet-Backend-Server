using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.src.ProductAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.ProductSizeService
{
    public class ProductSizeManagement : BaseService<ProductSize, ProductSizeReadDto, ProductSizeCreateDto, ProductSizeUpdateDto>, IProductSizeManagement
    {
        public async Task<ProductSizeCreateDto> CreateAsync(ProductSizeCreateDto createDto)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductSizeReadDto>> GetSizesByProductIdAsync(Guid productId)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductSizeUpdateDto> UpdateAsync(Guid id, ProductSizeUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}