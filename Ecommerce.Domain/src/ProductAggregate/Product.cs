using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.src.ProductAggregate
{
    public class Product : BaseEntity
    {
        [MaxLength(100)]
        public string Title { get; set; }

        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Required]
        public int Stock { get; set; }

        [MaxLength(100)]
        public string ProductLine { get; set; }



        // Navigation property
        public virtual Category Category { get; set; }

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