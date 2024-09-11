using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Domain.src.Entities.CartAggregate
{
    public class CartItem : BaseEntity
    {
        public Guid? UserId { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}