using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Domain.src.Entities.CartAggregate
{
    public class CartItem : BaseEntity
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int CartId { get; set; }

        public virtual Product? Product { get; set; }
    }
}