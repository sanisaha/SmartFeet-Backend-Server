using Ecommerce.Domain.src.Entities.ShipmentAggregate;
using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Service.src.ShipmentService;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Presentation.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ShipmentController : ControllerBase
    {
        private readonly IShipmentManagement _shipmentManagement;

        public ShipmentController(IShipmentManagement shipmentManagement)
        {
            _shipmentManagement = shipmentManagement;
        }

        // GET: api/v1/Shipment/Order/{orderId}
        [HttpGet("Order/{orderId:guid}")]
        public async Task<IActionResult> GetShipmentsByOrderId(Guid orderId)
        {
            var shipments = await _shipmentManagement.GetShipmentsByOrderIdAsync(orderId);
            if (shipments == null)
            {
                return NotFound("No shipments found for this order.");
            }
            return Ok(shipments);
        }


    }


}
