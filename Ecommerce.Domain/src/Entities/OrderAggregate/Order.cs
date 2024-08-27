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
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalPrice { get; set; }

        [ForeignKey("Address")]
        public Guid ShippingAddressId { get; set; }

        [Required]
        public OrderStatus OrderStatus { get; set; }

        // Navigation Properties
        public virtual IEnumerable<OrderItem> OrderItems { get; set; }

        // public virtual User User { get; set; }

        // public virtual Address Address { get; set; }


        // Constructor
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

        // public void AddOrderItem(OrderItem item)
        // {
        //     OrderItems.Add(item);
        //     TotalPrice += item.Price * item.Quantity;
        // }

        // public void RemoveOrderItem(OrderItem item)
        // {
        //     if (OrderItems.Remove(item))
        //     {
        //         TotalPrice -= item.Price * item.Quantity;
        //     }
        // }

        public void UpdateOrderStatus(OrderStatus status)
        {
            OrderStatus = status;
        }
    }
}