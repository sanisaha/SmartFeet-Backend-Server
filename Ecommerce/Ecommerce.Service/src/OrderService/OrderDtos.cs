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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PaymentMethod { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public ICollection<OrderItemReadDto> OrderItems { get; set; }
        //public IEnumerable<OrderItemReadDto> OrderItems { get; set; }

        public override void FromEntity(Order entity)
        {
            base.FromEntity(entity);
            UserId = entity.UserId;
            OrderDate = entity.OrderDate;
            TotalPrice = entity.TotalPrice;
            AddressId = entity.AddressId;
            FirstName = entity.FirstName;
            LastName = entity.LastName;
            PhoneNumber = entity.PhoneNumber;
            Email = entity.Email;
            PaymentMethod = entity.PaymentMethod;
            OrderStatus = entity.OrderStatus;
            OrderItems = entity.OrderItems?.Select(item =>
            {
                var orderItemDto = new OrderItemReadDto();
                orderItemDto.FromEntity(item);
                return orderItemDto;
            }).ToList();
        }
    }
    public class OrderCreateDto : ICreateDto<Order>
    {
        public Guid? UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid? AddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PaymentMethod { get; set; }
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
                OrderStatus = OrderStatus,
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber,
                Email = Email,
                PaymentMethod = PaymentMethod,
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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PaymentMethod { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public IEnumerable<OrderItemUpdateDto> OrderItems { get; set; }

        public Order UpdateEntity(Order entity)
        {
            entity.UserId = UserId;
            entity.OrderDate = OrderDate;
            entity.TotalPrice = TotalPrice;
            entity.AddressId = AddressId;
            entity.OrderStatus = OrderStatus;
            entity.FirstName = FirstName;
            entity.LastName = LastName;
            entity.PhoneNumber = PhoneNumber;
            entity.Email = Email;
            entity.PaymentMethod = PaymentMethod;
            //entity.OrderItems = OrderItems.Select(item => item.UpdateEntity(item)).ToList();
            return entity;
        }
    }
}