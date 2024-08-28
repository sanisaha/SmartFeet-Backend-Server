using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.src.CategoryAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.CategoryService
{
    public class CategoryManagement : BaseService<Category, CategoryReadDto, CategoryCreateDto, CategoryUpdateDto>, ICategoryManagement
    {
        public async Task<CategoryCreateDto> CreateAsync(CategoryCreateDto createDto)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryReadDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryUpdateDto> UpdateAsync(Guid id, CategoryUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}