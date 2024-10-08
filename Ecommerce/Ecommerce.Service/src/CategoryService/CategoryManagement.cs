using Ecommerce.Domain.Enums;
using Ecommerce.Domain.src.CategoryAggregate;
using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Domain.src.Model;
using Ecommerce.Domain.src.Shared;
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

        public async Task<IEnumerable<CategoryReadDto>> GetCategoryByIdAsync(Guid userId)
        {
            var categories = await _categoryRepository.GetCategoryByIdAsync(userId);
            return categories.Select(c => new CategoryReadDto
            {
                Id = c.Id,
                CategoryName = c.CategoryName,
            });
        }
        public override async Task<PaginatedResult<CategoryReadDto>> GetAllAsync(PaginationOptions paginationOptions)
        {
            var entities = await _categoryRepository.GetAllAsync(paginationOptions);
            var convertedResult = entities.Items.Select(entity =>
            {
                var readDto = Activator.CreateInstance<CategoryReadDto>();
                readDto.FromEntity(entity);
                return readDto;
            });
            return new PaginatedResult<CategoryReadDto>
            {
                Items = convertedResult,
                CurrentPage = entities.CurrentPage,
                TotalPages = entities.TotalPages
            };
        }
        public async Task<CategoryReadDto?> GetCategoryByNameAsync(CategoryName categoryName)
        {
            var category = await _categoryRepository.GetCategoryByNameAsync(categoryName);
            if (category == null)
            {
                return null;
            }
            var categoryDtos = new CategoryReadDto();
            categoryDtos.FromEntity(category);
            return categoryDtos;

        }

    }
}