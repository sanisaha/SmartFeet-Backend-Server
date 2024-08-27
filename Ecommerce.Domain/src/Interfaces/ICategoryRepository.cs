using Ecommerce.Domain.src.CategoryAggregate;

namespace Ecommerce.Domain.src.Interfaces
{
    public interface ICategoryRepository
    {
        public Category CreateCategory(Category category);
        public Category UpdateCategory(Category user);
        public bool DeleteCategory(Guid userId);
        public Category GetCategoryById(Guid userId);
        public IEnumerable<Category> GetAllCategory();
    }
}