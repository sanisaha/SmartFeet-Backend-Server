using Ecommerce.Domain.src.Entities.PaymentAggregate;
using Ecommerce.Domain.src.PaymentAggregate;

namespace Ecommerce.Domain.src.Interfaces
{
    public interface IPaymentRepository
    {
        Task<bool> CreatePaymentAsync(Payment payment);
        Task<bool> UpdatePaymentAsync(Payment payment);
        Task<bool> DeletePaymentAsync(Payment payment);
        Task<Payment> GetPaymentAsync(Payment payment);
        Task<IEnumerable<Payment>> GetAllPaymentAsync();
    }
}