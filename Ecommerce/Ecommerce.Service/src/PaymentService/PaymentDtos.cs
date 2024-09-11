using Ecommerce.Domain.Enums;
using Ecommerce.Domain.src.Entities.PaymentAggregate;
using Ecommerce.Domain.src.PaymentAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.PaymentService
{
    public class PaymentReadDto : BaseReadDto<Payment>
    {
        public Guid OrderId { get; set; }
        public Guid? UserId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        public override void FromEntity(Payment entity)
        {
            base.FromEntity(entity);
            OrderId = entity.OrderId;
            UserId = entity.UserId;
            PaymentMethod = entity.PaymentMethod;
            Amount = entity.Amount;
            PaymentDate = entity.PaymentDate;
            PaymentStatus = entity.PaymentStatus;
        }
    }
    public class PaymentCreateDto : ICreateDto<Payment>
    {
        public Guid OrderId { get; set; }
        public Guid? UserId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public Payment CreateEntity()
        {
            return new Payment
            {
                OrderId = OrderId,
                UserId = UserId,
                PaymentMethod = PaymentMethod,
                Amount = Amount,
                PaymentStatus = PaymentStatus
            };
        }
    }
    public class PaymentUpdateDto : IUpdateDto<Payment>
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public Payment UpdateEntity(Payment entity)
        {
            entity.OrderId = OrderId;
            entity.UserId = UserId;
            entity.PaymentMethod = PaymentMethod;
            entity.Amount = Amount;
            entity.PaymentStatus = PaymentStatus;
            return entity;
        }
    }
}