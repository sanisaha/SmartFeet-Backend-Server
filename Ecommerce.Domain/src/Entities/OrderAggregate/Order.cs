using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ecommerce.Domain.Enums;
using Ecommerce.Domain.src.AddressAggregate;
using Ecommerce.Domain.src.Shared;
using Ecommerce.Domain.src.UserAggregate;

namespace Ecommerce.Domain.src.Entities.OrderAggregate
{
    public class Order : BaseEntity
    {
        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalPrice { get; set; }

        [Required]
        public OrderStatus OrderStatus { get; set; }

        public Guid? UserId { get; set; }

        public Guid? AddressId { get; set; }

        // Navigation Properties
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual User? User { get; set; }
        public virtual Address? Address { get; set; }

        // Methods
        public void AddOrderItem(OrderItem item)
        {
            OrderItems.Add(item);
            TotalPrice += item.Price * item.Quantity;
        }

        public void RemoveOrderItem(OrderItem item)
        {
            if (OrderItems.Remove(item))
            {
                TotalPrice -= item.Price * item.Quantity;
            }
        }

        public void UpdateOrderStatus(OrderStatus status)
        {
            OrderStatus = status;
        }
    }
}
