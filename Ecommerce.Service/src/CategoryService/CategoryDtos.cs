using Ecommerce.Domain.src.CategoryAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.CategoryService
{
    public class CategoryReadDto : BaseReadDto<Category>
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }

        public override void FromEntity(Category entity)
        {
            base.FromEntity(entity);
            CategoryId = entity.CategoryId;
            Name = entity.Name;
        }
    }
    public class CategoryCreateDto : ICreateDto<Category>
    {
        public string? Name { get; set; }
        public int ParentCategoryId { get; set; }
        public Category CreateEntity()
        {
            return new Category
            {
                Name = Name,
                ParentCategoryId = ParentCategoryId
            };
        }
    }
    public class CategoryUpdateDto : IUpdateDto<Category>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int ParentCategoryId { get; set; }
        public Category UpdateEntity(Category entity)
        {
            entity.Name = Name;
            entity.ParentCategoryId = ParentCategoryId;
            return entity;
        }
    }
}