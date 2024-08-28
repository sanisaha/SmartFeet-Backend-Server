using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ecommerce.Service.src.AddressService;
using Ecommerce.Service.src.CategoryService;
using Ecommerce.Service.src.Shared;
using Ecommerce.Service.src.UserService;

namespace Ecommerce.Service.src.OrderService
{
    public class Product : BaseEntity
    {
        [MaxLength(100)]
        public string Title { get; set; }

        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Required]
        public int Stock { get; set; }

        [MaxLength(100)]
        public string ProductLine { get; set; }



        // Navigation property
        public virtual Category Category { get; set; }

        public bool IsInStock()
        {
            return Stock > 0;
        }

        public void UpdateStock(int quantity)
        {
            if (quantity < 0 && Stock + quantity < 0)
            {
                throw new ArgumentException("Insufficient stock.");
            }
            Stock += quantity;
            UpdateTimestamps();  // Update UpdatedAt timestamp
        }
    }
    public enum OrderStatus
    {
        Pending,
        Processing,
        OnHold,
        Shipped,
        Delivered,
        Completed,
        Canceled,
        Refunded,
        Returned,
        Failed

    }
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
    public class OrderItem : BaseEntity
    {
        [Required]
        public Guid OrderId { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        // Navigation Property
        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
    public interface IOrder
    {
        Guid UserId { get; set; }
        DateTime OrderDate { get; set; }
        decimal TotalPrice { get; set; }
        Guid ShippingAddressId { get; set; }
        OrderStatus OrderStatus { get; set; }
        ICollection<OrderItem> OrderItems { get; set; }

        void AddOrderItem(OrderItem item);
        void RemoveOrderItem(OrderItem item);
        void UpdateOrderStatus(OrderStatus status);
    }

    // Product, Order, OrderItem should be in the domain layer, need to remove
    public class OrderReadDto : BaseReadDto<Order>
    {
        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid ShippingAddressId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public IEnumerable<OrderItemReadDto> OrderItems { get; set; }

        public override void FromEntity(Order entity)
        {
            UserId = entity.UserId;
            OrderDate = entity.OrderDate;
            TotalPrice = entity.TotalPrice;
            ShippingAddressId = entity.ShippingAddressId;
            OrderStatus = entity.OrderStatus;
            //OrderItems = entity.OrderItems.Select(item => new OrderItemReadDto().FromEntity(item)).ToList();
            base.FromEntity(entity);
        }
    }
    public class OrderCreateDto : ICreateDto<Order>
    {
        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid ShippingAddressId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public IEnumerable<OrderItemCreateDto> OrderItems { get; set; }

        public Order CreateEntity()
        {
            return new Order
            {
                UserId = UserId,
                OrderDate = OrderDate,
                TotalPrice = TotalPrice,
                ShippingAddressId = ShippingAddressId,
                OrderStatus = OrderStatus,
                OrderItems = OrderItems.Select(item => item.CreateEntity()).ToList()
            };
        }
    }
    public class OrderUpdateDto : IUpdateDto<Order>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid ShippingAddressId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public IEnumerable<OrderItemUpdateDto> OrderItems { get; set; }

        public Order UpdateEntity(Order entity)
        {
            entity.UserId = UserId;
            entity.OrderDate = OrderDate;
            entity.TotalPrice = TotalPrice;
            entity.ShippingAddressId = ShippingAddressId;
            entity.OrderStatus = OrderStatus;
            //entity.OrderItems = OrderItems.Select(item => item.UpdateEntity(item)).ToList();
            return entity;
        }
    }
}