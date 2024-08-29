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

    }
}
