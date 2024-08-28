using Ecommerce.Domain.src.CategoryAggregate;

namespace Ecommerce.Domain.src.Interfaces
{
    public interface ICategoryRepository
    {
        Task<bool> CreateCategoryAsync(Category category);
        Task<bool> UpdateCategoryAsync(Category user);
        Task<bool> DeleteCategoryAsync(Guid userId);
        Task<Category> GetCategoryByIdAsync(Guid userId);
        Task<IEnumerable<Category>> GetAllCategoryAsync();
    }
}