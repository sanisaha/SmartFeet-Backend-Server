using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.Enums;
using Ecommerce.Domain.src.CategoryAggregate;
using Ecommerce.Domain.src.ProductAggregate;
using Ecommerce.Domain.src.Shared;

namespace Ecommerce.Domain.src.Entities.SubCategoryAggregate
{
    public class SubCategory : BaseEntity
    {
        public SubCategoryName SubCategoryName { get; set; }
        public Guid CategoryId { get; set; }

        public virtual Category? Category { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}