using Ecommerce.Domain.src.CategoryAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.CategoryService
{
    public interface ICategoryManagement : IBaseService<Category, CategoryReadDto, CategoryCreateDto, CategoryUpdateDto>
    {
        Task<Category> CreateAsync(CategoryCreateDto createDto);
        Task<bool> UpdateAsync(Guid id, CategoryUpdateDto updateDto);
        Task<CategoryReadDto> GetByIdAsync(Guid id);
        Task<bool> DeleteAsync(Guid id);

    }
}