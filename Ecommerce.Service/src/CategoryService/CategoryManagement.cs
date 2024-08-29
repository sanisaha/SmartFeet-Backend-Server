using Ecommerce.Domain.src.CategoryAggregate;
using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.CategoryService
{
    public class CategoryManagement : BaseService<Category, CategoryReadDto, CategoryCreateDto, CategoryUpdateDto>, ICategoryManagement
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManagement(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Category> CreateAsync(CategoryCreateDto createDto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(createDto.Name))
                    throw new ArgumentException("Category name is required.");

                var categoryEntity = createDto.CreateEntity();
                return await _categoryRepository.CreateAsync(categoryEntity);

            }
            catch (Exception)
            {
                throw new Exception("Error creating category!.");
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var category = await _categoryRepository.GetAsync(c => c.Id == id);
                if (category == null)
                    throw new ArgumentException("Category not found.");

                return await _categoryRepository.DeleteByIdAsync(id);
            }
            catch (Exception)
            {
                throw new Exception("Error deleting category!.");
            }
        }

        public async Task<CategoryReadDto> GetByIdAsync(Guid id)
        {
            try
            {
                var category = await _categoryRepository.GetAsync(c => c.Id == id);
                if (category == null)
                    throw new ArgumentException("Category not found.");

                var categoryDto = new CategoryReadDto();
                categoryDto.FromEntity(category);

                return categoryDto;
            }
            catch (Exception)
            {
                throw new Exception("Error retrieving category!.");
            }
        }

        public async Task<bool> UpdateAsync(Guid id, CategoryUpdateDto updateDto)
        {
            try
            {
                var existingCategory = await _categoryRepository.GetAsync(c => c.Id == id);
                if (existingCategory == null)
                    throw new ArgumentException("Category not found.");

                if (string.IsNullOrWhiteSpace(updateDto.Name))
                    throw new ArgumentException("Category name is required.");

                var updatedCategory = updateDto.UpdateEntity(existingCategory);

                return await _categoryRepository.UpdateByIdAsync(updatedCategory);

            }
            catch (Exception)
            {
                throw new Exception("Error updating category!.");
            }
        }
    }
}