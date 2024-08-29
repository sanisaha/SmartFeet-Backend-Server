using Ecommerce.Domain.src.Entities.PaymentAggregate;
using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Service.src.PaymentService;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Presentation.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentManagement _paymentManagement;

        public PaymentController(IPaymentManagement paymentManagement)
        {
            _paymentManagement = paymentManagement;
        }

        // GET: api/v1/Payment/User/{userId}
        [HttpGet("User/{userId:guid}")]
        public async Task<IActionResult> GetAllUserPaymentAsync(Guid userId)
        {
            var payments = await _paymentManagement.GetAllUserPaymentAsync(userId);
            if (payments == null)
            {
                return NotFound("No payments found for this user.");
            }
            return Ok(payments);
        }
    }
}
