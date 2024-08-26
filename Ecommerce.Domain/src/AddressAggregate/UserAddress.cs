using System.ComponentModel.DataAnnotations;
using Ecommerce.Domain.src.UserAggregate;

namespace Ecommerce.Domain.src.AddressAggregate
{
    public class UserAddress
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid AddressId { get; set; }

        public bool IsDefault { get; set; }

    }
}