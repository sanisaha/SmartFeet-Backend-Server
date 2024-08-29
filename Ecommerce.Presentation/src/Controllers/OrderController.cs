using Ecommerce.Domain.Enums;
using Ecommerce.Domain.src.Entities.OrderAggregate;
using Ecommerce.Domain.src.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Presentation.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // GET: api/v1/order/{userId}
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetOrdersByUserId(Guid userId)
        {
            var orders = await _orderRepository.GetOrdersByUserIdAsync(userId);
            return Ok(orders);
        }

        // GET: api/v1/order/status/{status}
        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetOrdersByStatus(OrderStatus status)
        {
            var orders = await _orderRepository.GetOrdersByStatusAsync(status);
            return Ok(orders);
        }

        // GET: api/v1/order/date-range
        [HttpGet("date-range")]
        public async Task<IActionResult> GetOrdersByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var orders = await _orderRepository.GetOrdersByDateRangeAsync(startDate, endDate);
            return Ok(orders);
        }

        // GET: api/v1/order/total-price/{orderId}
        [HttpGet("total-price/{orderId}")]
        public async Task<IActionResult> GetTotalPriceByOrderId(Guid orderId)
        {
            try
            {
                var totalPrice = await _orderRepository.GetTotalPriceByOrderIdAsync(orderId);
                return Ok(new { OrderId = orderId, TotalPrice = totalPrice });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/v1/order/total-orders
        [HttpGet("total-orders")]
        public async Task<IActionResult> GetTotalOrders([FromQuery] DateTime? startDate = null, [FromQuery] DateTime? endDate = null)
        {
            var totalOrders = await _orderRepository.GetTotalOrdersAsync(startDate, endDate);
            return Ok(new { TotalOrders = totalOrders });
        }

        // POST: api/v1/order
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdOrder = await _orderRepository.CreateAsync(order);
            return CreatedAtAction(nameof(GetOrdersByUserId), new { userId = createdOrder.UserId }, createdOrder);
        }

        // PUT: api/v1/order/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(Guid id, [FromBody] Order order)
        {
            if (id != order.Id)
            {
                return BadRequest("Order ID mismatch");
            }

            var result = await _orderRepository.UpdateByIdAsync(order);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/v1/order/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var result = await _orderRepository.DeleteByIdAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
