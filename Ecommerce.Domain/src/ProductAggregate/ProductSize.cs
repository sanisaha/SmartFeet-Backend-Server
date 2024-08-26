using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.Enums;

namespace Ecommerce.Domain.src.ProductAggregate
{
    public class ProductSize : BaseEntity
    {
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }

        [Required]
        public SizeValue SizeValue { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        // Navigation property
        public virtual Product Product { get; set; }
    }
}