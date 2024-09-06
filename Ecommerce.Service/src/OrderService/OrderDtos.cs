using Ecommerce.Domain.Enums;
using Ecommerce.Domain.src.AddressAggregate;
using Ecommerce.Domain.src.Entities.OrderAggregate;
using Ecommerce.Service.src.OrderItemService;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.OrderService
{
    public class OrderReadDto : BaseReadDto<Order>
    {
        public Guid? UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid? AddressId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        //public IEnumerable<OrderItemReadDto> OrderItems { get; set; }

        public override void FromEntity(Order entity)
        {
            UserId = entity.UserId;
            OrderDate = entity.OrderDate;
            TotalPrice = entity.TotalPrice;
            AddressId = entity.AddressId;
            OrderStatus = entity.OrderStatus;
            //OrderItems = entity.OrderItems.Select(item => new OrderItemReadDto().FromEntity(item)).ToList();
            base.FromEntity(entity);
        }
    }
    public class OrderCreateDto : ICreateDto<Order>
    {
        public Guid? UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid? AddressId { get; set; }
        public OrderStatus OrderStatus { get; set; }

        //public IEnumerable<OrderItemCreateDto> OrderItems { get; set; }

        public Order CreateEntity()
        {
            return new Order
            {
                UserId = UserId,
                OrderDate = OrderDate,
                TotalPrice = TotalPrice,
                AddressId = AddressId,
                OrderStatus = OrderStatus
                //OrderItems = OrderItems.Select(item => item.CreateEntity()).ToList()
            };
        }
    }
    public class OrderUpdateDto : IUpdateDto<Order>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid AddressId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public IEnumerable<OrderItemUpdateDto> OrderItems { get; set; }

        public Order UpdateEntity(Order entity)
        {
            entity.UserId = UserId;
            entity.OrderDate = OrderDate;
            entity.TotalPrice = TotalPrice;
            entity.AddressId = AddressId;
            entity.OrderStatus = OrderStatus;
            //entity.OrderItems = OrderItems.Select(item => item.UpdateEntity(item)).ToList();
            return entity;
        }
    }
}