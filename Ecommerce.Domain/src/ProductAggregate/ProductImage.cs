using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Domain.src.ProductAggregate
{
    public class ProductImage : BaseEntity
    {
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(200)]
        public string ImageURL { get; set; }

        [Required]
        public bool IsPrimary { get; set; }

        [MaxLength(200)]
        public string ImageText { get; set; }

        // Navigation property
        public virtual Product Product { get; set; }
    }
}