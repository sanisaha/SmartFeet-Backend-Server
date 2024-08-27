using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.CategoryService
{
    public class CategoryManagement : BaseService<Category, CategoryReadDto, CategoryCreateDto, CategoryUpdateDto>, ICategoryManagement
    {
        public Task<CategoryCreateDto> CreateAsync(CategoryCreateDto createDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryReadDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryUpdateDto> UpdateAsync(Guid id, CategoryUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}