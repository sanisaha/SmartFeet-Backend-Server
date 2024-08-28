using Ecommerce.Domain.src.CategoryAggregate;
using Ecommerce.Domain.src.Interface;

namespace Ecommerce.Domain.src.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<Category> GetCategoryByIdAsync(Guid userId);
        Task<IEnumerable<Category>> GetAllCategoryAsync();
    }
}