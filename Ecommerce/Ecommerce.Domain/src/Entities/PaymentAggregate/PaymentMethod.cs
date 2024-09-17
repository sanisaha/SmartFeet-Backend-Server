
using System.ComponentModel.DataAnnotations;
using Ecommerce.Domain.src.Entities.PaymentAggregate;
using Ecommerce.Domain.src.Shared;

namespace Ecommerce.Domain.src.PaymentAggregate
{
    public class PaymentMethod : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string? PaymentType { get; set; }

        [Required]
        [StringLength(50)]
        public string? Provider { get; set; }

        [Required]
        [StringLength(50)]
        public string? CardNumber { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }

        [Required]
        [StringLength(50)]
        public string CVV { get; set; }

    }
}