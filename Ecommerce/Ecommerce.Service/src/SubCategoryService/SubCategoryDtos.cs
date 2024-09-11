using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.Enums;
using Ecommerce.Domain.src.Entities.SubCategoryAggregate;
using Ecommerce.Domain.src.ProductAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.SubCategoryService
{
    public class SubCategoryReadDto : BaseReadDto<SubCategory>
    {
        public Guid SubCategoryId { get; set; }
        public SubCategoryName SubCategoryName { get; set; }
        public Guid CategoryId { get; set; }
        public ICollection<Product> Products { get; set; }

        public override void FromEntity(SubCategory entity)
        {
            base.FromEntity(entity);
            SubCategoryId = entity.Id;
            SubCategoryName = entity.SubCategoryName;
            CategoryId = entity.CategoryId;
            Products = entity.Products;
        }
    }
    public class SubCategoryCreateDto : ICreateDto<SubCategory>
    {
        public SubCategoryName SubCategoryName { get; set; }
        public Guid CategoryId { get; set; }
        public SubCategory CreateEntity()
        {
            return new SubCategory
            {
                SubCategoryName = SubCategoryName,
                CategoryId = CategoryId
            };
        }
    }
    public class SubCategoryUpdateDto : IUpdateDto<SubCategory>
    {
        public Guid Id { get; set; }
        public SubCategoryName SubCategoryName { get; set; }
        public Guid CategoryId { get; set; }
        public SubCategory UpdateEntity(SubCategory entity)
        {
            entity.SubCategoryName = SubCategoryName;
            entity.CategoryId = CategoryId;
            return entity;
        }
    }
}