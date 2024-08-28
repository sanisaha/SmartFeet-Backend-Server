using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.src.ProductAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.ProductService
{
    public class ProductManagement : BaseService<Product, ProductReadDto, ProductCreateDto, ProductUpdateDto>, IProductManagement
    {
        public async Task<ProductCreateDto> CreateAsync(ProductCreateDto createDto)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductReadDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductUpdateDto> UpdateAsync(Guid id, ProductUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}