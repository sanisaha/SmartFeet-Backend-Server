using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.src.CategoryAggregate
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        public int ParentCategoryId { get; set; }
    }
}