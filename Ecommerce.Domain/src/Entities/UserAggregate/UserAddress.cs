using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.src.AddressAggregate;
using Ecommerce.Domain.src.UserAggregate;

namespace Ecommerce.Domain.src.Entities.UserAggregate
{
    public class UserAddress
    {
        public Guid UserId { get; set; }
        public Guid AddressId { get; set; }
        public bool IsDefault { get; set; } = false;

        // Navigation properties
        public virtual User? User { get; set; }
        public virtual Address? Address { get; set; }
    }
}