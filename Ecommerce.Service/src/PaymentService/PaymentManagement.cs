using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.PaymentService
{
    public class PaymentManagement : BaseService<Payment, PaymentReadDto, PaymentCreateDto, PaymentUpdateDto>, IPaymentManagement
    {
        public async Task<PaymentCreateDto> CreateAsync(PaymentCreateDto createDto)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PaymentReadDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PaymentUpdateDto> UpdateAsync(Guid id, PaymentUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}