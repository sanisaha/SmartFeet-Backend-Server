using Ecommerce.Domain.src.Entities.OrderAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.OrderItemService
{
    public class OrderItemCreateDto : ICreateDto<OrderItem>
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public OrderItem CreateEntity()
        {
            return new OrderItem
            {
                OrderId = OrderId,
                ProductId = ProductId,
                Quantity = Quantity,
                Price = Price
            };
        }
    }
    public class OrderItemUpdateDto : IUpdateDto<OrderItem>
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public OrderItem UpdateEntity(OrderItem entity)
        {
            entity.OrderId = OrderId;
            entity.ProductId = ProductId;
            entity.Quantity = Quantity;
            entity.Price = Price;
            return entity;
        }
    }
    public class OrderItemReadDto : BaseReadDto<OrderItem>
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public override void FromEntity(OrderItem entity)
        {
            OrderId = entity.OrderId;
            ProductId = entity.ProductId;
            Quantity = entity.Quantity;
            Price = entity.Price;
        }
    }
}