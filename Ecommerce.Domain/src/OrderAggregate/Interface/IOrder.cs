namespace Ecommerce.Domain.src.OrderAggregate.Interface
{
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
        void UpdateOrderStatus(OrderStatus status)
    }
}