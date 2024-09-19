using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ecommerce.Domain.Enums;
using Ecommerce.Domain.src.CategoryAggregate;
using Ecommerce.Domain.src.Entities.OrderAggregate;
using Ecommerce.Domain.src.Entities.ProductAggregate;
using Ecommerce.Domain.src.Entities.ReviewAggregate;
using Ecommerce.Domain.src.Entities.SubCategoryAggregate;
using Ecommerce.Domain.src.Shared;

namespace Ecommerce.Domain.src.ProductAggregate
{
    public class Product : BaseEntity
    {
        [MaxLength(150)]
        public string? Title { get; set; }

        //[ForeignKey("Category")]
        public Guid SubCategoryId { get; set; }

        [Required]
        [MaxLength(400)]
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Required]
        public int Stock { get; set; }

        [MaxLength(100)]
        public string? BrandName { get; set; }

        public int? Discount { get; set; }
        public int? OldPrice { get; set; }
        public bool IsFeatured { get; set; }
        public CategoryName CategoryName { get; set; }
        public SubCategoryName SubCategoryName { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

        // Navigation property
        public virtual SubCategory? SubCategory { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<ProductSize> ProductSizes { get; set; }
        public virtual ICollection<ProductColor> ProductColors { get; set; }

        public bool IsInStock()
        {
            return Stock > 0;
        }

        public void UpdateStock(int quantity)
        {
            if (quantity < 0 && Stock + quantity < 0)
            {
                throw new ArgumentException("Insufficient stock.");
            }
            Stock += quantity;
            UpdateTimestamps();  // Update UpdatedAt timestamp
        }
    }
}