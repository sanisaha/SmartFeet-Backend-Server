using Ecommerce.Domain.Enums;
using Ecommerce.Domain.src.CategoryAggregate;
using Ecommerce.Domain.src.Entities.SubCategoryAggregate;
using Ecommerce.Domain.src.ProductAggregate;
using Ecommerce.Service.src.Shared;
using Ecommerce.Service.src.SubCategoryService;

namespace Ecommerce.Service.src.CategoryService
{
    public class CategoryReadDto : BaseReadDto<Category>
    {
        public Guid CategoryId { get; set; }
        public CategoryName CategoryName { get; set; }
        public ICollection<SubCategoryReadDto> SubCategories { get; set; }

        public override void FromEntity(Category entity)
        {
            base.FromEntity(entity);
            CategoryId = entity.ParentCategoryId;
            CategoryName = entity.CategoryName;
            SubCategories = entity.SubCategories?.Select(x =>
            {
                var subCategoryDto = new SubCategoryReadDto();
                subCategoryDto.FromEntity(x);
                return subCategoryDto;
            }).ToList();

        }
    }
    public class CategoryCreateDto : ICreateDto<Category>
    {
        public CategoryName CategoryName { get; set; }
        public Guid ParentCategoryId { get; set; }
        public Category CreateEntity()
        {
            return new Category
            {
                CategoryName = CategoryName,
                ParentCategoryId = ParentCategoryId
            };
        }
    }
    public class CategoryUpdateDto : IUpdateDto<Category>
    {
        public Guid Id { get; set; }
        public CategoryName CategoryName { get; set; }
        public Guid ParentCategoryId { get; set; }
        public Category UpdateEntity(Category entity)
        {
            entity.CategoryName = CategoryName;
            entity.ParentCategoryId = ParentCategoryId;
            return entity;
        }
    }
}