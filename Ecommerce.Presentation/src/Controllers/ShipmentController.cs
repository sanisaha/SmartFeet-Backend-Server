using Ecommerce.Domain.src.Entities.ShipmentAggregate;
using Ecommerce.Domain.src.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Presentation.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ShipmentController : ControllerBase
    {
        private readonly IShipmentRepository _shipmentRepository;

        public ShipmentController(IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
        }

        // GET: api/v1/Shipment
        [HttpGet]
        public async Task<IActionResult> GetAllShipments()
        {
            var shipments = await _shipmentRepository.GetAllShipments();
            return Ok(shipments);
        }

        // GET: api/v1/Shipment/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetShipmentById(Guid id)
        {
            var shipment = await _shipmentRepository.GetAsync(s => s.Id == id);
            if (shipment == null)
            {
                return NotFound("Shipment not found.");
            }
            return Ok(shipment);
        }

        // POST: api/v1/Shipment
        [HttpPost]
        public async Task<IActionResult> CreateShipment([FromBody] Shipment shipment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdShipment = await _shipmentRepository.CreateAsync(shipment);
            return CreatedAtAction(nameof(GetShipmentById), new { id = createdShipment.Id }, createdShipment);
        }

        // PUT: api/v1/Shipment/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateShipment(Guid id, [FromBody] Shipment shipment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != shipment.Id)
            {
                return BadRequest("ID mismatch.");
            }
            var updateResult = await _shipmentRepository.UpdateByIdAsync(shipment);
            if (!updateResult)
            {
                return NotFound("Shipment not found.");
            }
            return NoContent();
        }

        // DELETE: api/v1/Shipment/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteShipment(Guid id)
        {
            var deleteResult = await _shipmentRepository.DeleteByIdAsync(id);
            if (!deleteResult)
            {
                return NotFound("Shipment not found.");
            }
            return NoContent();
        }
    }
}
