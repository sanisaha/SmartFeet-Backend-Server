using Ecommerce.Domain.Enums;
using Ecommerce.Domain.src.CategoryAggregate;
using Ecommerce.Domain.src.ProductAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.CategoryService
{
    public class CategoryReadDto : BaseReadDto<Category>
    {
        public Guid CategoryId { get; set; }
        public CategoryName CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }

        public override void FromEntity(Category entity)
        {
            base.FromEntity(entity);
            CategoryId = entity.ParentCategoryId;
            CategoryName = entity.CategoryName;
            Products = entity.Products;
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