using Ecommerce.Domain.Enums;
using Ecommerce.Domain.src.CategoryAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.CategoryService
{
    public interface ICategoryManagement : IBaseService<Category, CategoryReadDto, CategoryCreateDto, CategoryUpdateDto>
    {
        Task<IEnumerable<CategoryReadDto>> GetCategoryByIdAsync(Guid userId);
        Task<CategoryReadDto> GetCategoryByNameAsync(CategoryName categoryName);
    }
}