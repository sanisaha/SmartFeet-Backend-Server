
using Ecommerce.Domain.src.Entities.PaymentAggregate;
using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.PaymentService
{
    public class PaymentManagement : BaseService<Payment, PaymentReadDto, PaymentCreateDto, PaymentUpdateDto>, IPaymentManagement
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentManagement(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public async Task<PaymentReadDto> CreateAsync(PaymentCreateDto createDto)
        {
            try
            {
                var payment = createDto.CreateEntity();
                await _paymentRepository.CreateAsync(payment);
                var paymentDto = new PaymentReadDto();
                paymentDto.FromEntity(payment);
                return paymentDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var payment = await _paymentRepository.GetAsync(p => p.Id == id);
                if (payment == null)
                    throw new ArgumentException("Payment not found.");

                await _paymentRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PaymentReadDto> GetByIdAsync(Guid id)
        {
            try
            {
                var payment = await _paymentRepository.GetAsync(p => p.Id == id);
                if (payment == null)
                    throw new ArgumentException("Payment not found.");

                var paymentDto = new PaymentReadDto();
                paymentDto.FromEntity(payment);

                return paymentDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PaymentUpdateDto> UpdateAsync(Guid id, PaymentUpdateDto updateDto)
        {
            try
            {
                var payment = await _paymentRepository.GetAsync(p => p.Id == id);
                if (payment == null)
                    throw new ArgumentException("Payment not found.");

                payment = updateDto.UpdateEntity(payment);
                await _paymentRepository.UpdateByIdAsync(payment);
                return updateDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}