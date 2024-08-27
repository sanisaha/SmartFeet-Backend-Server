using Ecommerce.Domain.src.PaymentAggregate;

namespace Ecommerce.Domain.src.Interfaces
{
    public interface IPaymentRepository
    {
        public Payment CreatePayment(Payment payment);
        public Payment UpdatePayment(Payment payment);

    }
}