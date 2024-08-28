using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.src.Entities.ProductAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.ProductColorService
{
    public class ProductColorManagement : BaseService<ProductColor, ProductColorReadDto, ProductColorCreateDto, ProductColorUpdateDto>, IProductColorManagement
    {
        public async Task<ProductColorCreateDto> CreateAsync(ProductColorCreateDto createDto)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductColorUpdateDto> UpdateAsync(Guid id, ProductColorUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<ProductColorReadDto>> GetColorsByProductIdAsync(Guid productId)
        {
            throw new NotImplementedException();
        }
        public async Task<ProductColorReadDto> GetColorByNameAsync(string colorName)
        {
            throw new NotImplementedException();
        }
    }
}