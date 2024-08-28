using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.PaymentService
{
    public interface IPaymentManagement : IBaseService<Payment, PaymentReadDto, PaymentCreateDto, PaymentUpdateDto>
    {
        Task<PaymentCreateDto> CreateAsync(PaymentCreateDto createDto);
        Task<PaymentUpdateDto> UpdateAsync(Guid id, PaymentUpdateDto updateDto);
        Task<PaymentReadDto> GetByIdAsync(Guid id);
        public Task DeleteAsync(Guid id);

    }
}