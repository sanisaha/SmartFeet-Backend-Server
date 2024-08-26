
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ecommerce.Domain.Enums;

namespace Ecommerce.Domain.src.ProductAggregate
{
    public class ProductColor : BaseEntity
    {
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }

        [Required]
        public ColorName ColorName { get; set; }

        // Navigation property
        public virtual Product Product { get; set; }
    }
}