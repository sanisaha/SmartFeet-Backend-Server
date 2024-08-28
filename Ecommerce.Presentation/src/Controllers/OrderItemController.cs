using Ecommerce.Domain.src.Entities.OrderAggregate;
using Ecommerce.Domain.src.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Presentation.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemController(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        // GET: api/v1/orderitems/order/{orderId}
        [HttpGet("order/{orderId}")]
        public async Task<IActionResult> GetOrderItemsByOrderId(Guid orderId)
        {
            var orderItems = await _orderItemRepository.GetOrderItemsByOrderIdAsync(orderId);
            return Ok(orderItems);
        }

        // GET: api/v1/orderitems/product/{productId}
        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetOrderItemsByProductId(Guid productId)
        {
            var orderItems = await _orderItemRepository.GetOrderItemsByProductIdAsync(productId);
            return Ok(orderItems);
        }

        // GET: api/v1/orderitems/quantity/{orderId}
        [HttpGet("quantity/{orderId}")]
        public async Task<IActionResult> GetTotalQuantityByOrderId(Guid orderId)
        {
            var totalQuantity = await _orderItemRepository.GetTotalQuantityByOrderIdAsync(orderId);
            return Ok(new { OrderId = orderId, TotalQuantity = totalQuantity });
        }

        // POST: api/v1/orderitems
        [HttpPost]
        public async Task<IActionResult> CreateOrderItem([FromBody] OrderItem orderItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdOrderItem = await _orderItemRepository.CreateAsync(orderItem);
            return CreatedAtAction(nameof(GetOrderItemsByOrderId), new { orderId = createdOrderItem.OrderId }, createdOrderItem);
        }

        // PUT: api/v1/orderitems/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderItem(Guid id, [FromBody] OrderItem orderItem)
        {
            if (id != orderItem.Id)
            {
                return BadRequest("OrderItem ID mismatch");
            }

            var result = await _orderItemRepository.UpdateByIdAsync(orderItem);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/v1/orderitems/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(Guid id)
        {
            var result = await _orderItemRepository.DeleteByIdAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
