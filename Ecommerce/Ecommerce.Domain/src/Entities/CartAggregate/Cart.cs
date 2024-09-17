using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.src.Shared;

namespace Ecommerce.Domain.src.Entities.CartAggregate
{
    public class Cart : BaseEntity
    {
        public Guid? UserId { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}