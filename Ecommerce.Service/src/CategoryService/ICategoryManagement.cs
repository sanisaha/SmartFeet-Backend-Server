using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.src.CategoryAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.CategoryService
{
    public interface ICategoryManagement : IBaseService<Category, CategoryReadDto, CategoryCreateDto, CategoryUpdateDto>
    {
        Task<CategoryCreateDto> CreateAsync(CategoryCreateDto createDto);
        Task<CategoryUpdateDto> UpdateAsync(Guid id, CategoryUpdateDto updateDto);
        Task<CategoryReadDto> GetByIdAsync(Guid id);
        public Task DeleteAsync(Guid id);

    }
}