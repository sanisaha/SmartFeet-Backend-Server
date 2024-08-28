using Ecommerce.Domain.src.Entities.PaymentAggregate;
using Ecommerce.Domain.src.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Presentation.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        // GET: api/v1/Payment/User/{userId}
        [HttpGet("User/{userId:guid}")]
        public async Task<IActionResult> GetAllUserPayments(Guid userId)
        {
            var payments = await _paymentRepository.GetAllUserPaymentAsync(userId);
            if (payments == null)
            {
                return NotFound("No payments found for this user.");
            }
            return Ok(payments);
        }

        // GET: api/v1/Payment/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPaymentById(Guid id)
        {
            var payment = await _paymentRepository.GetAsync(p => p.Id == id);
            if (payment == null)
            {
                return NotFound("Payment not found.");
            }
            return Ok(payment);
        }

        // POST: api/v1/Payment
        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] Payment payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdPayment = await _paymentRepository.CreateAsync(payment);
            return CreatedAtAction(nameof(GetPaymentById), new { id = createdPayment.Id }, createdPayment);
        }

        // PUT: api/v1/Payment/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdatePayment(Guid id, [FromBody] Payment payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != payment.Id)
            {
                return BadRequest("ID mismatch.");
            }
            var updateResult = await _paymentRepository.UpdateByIdAsync(payment);
            if (!updateResult)
            {
                return NotFound("Payment not found.");
            }
            return NoContent();
        }

        // DELETE: api/v1/Payment/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePayment(Guid id)
        {
            var deleteResult = await _paymentRepository.DeleteByIdAsync(id);
            if (!deleteResult)
            {
                return NotFound("Payment not found.");
            }
            return NoContent();
        }
    }
}
