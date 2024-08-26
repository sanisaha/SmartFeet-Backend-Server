
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ecommerce.Domain.Enums;
using Ecommerce.Domain.src.OrderAggregate.Interface;

namespace Ecommerce.Domain.src.OrderAggregate
{
    public class Order : BaseEntity, IOrder
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
        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public virtual User User { get; set; }

        public virtual Address Address { get; set; }


        // Constructor
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

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