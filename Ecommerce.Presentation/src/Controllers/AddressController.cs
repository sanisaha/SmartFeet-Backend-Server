using Ecommerce.Domain.src.AddressAggregate;
using Ecommerce.Domain.src.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Presentation.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        // GET: api/v1/Address
        [HttpGet]
        public async Task<IActionResult> GetAllAddresses()
        {
            var addresses = await _addressRepository.GetAllAddressesAsync();
            return Ok(addresses);
        }

        // GET: api/v1/Address/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAddressById(Guid id)
        {
            var address = await _addressRepository.GetAddressByIdAsync(id);
            if (address == null)
            {
                return NotFound("Address not found.");
            }
            return Ok(address);
        }

        // POST: api/v1/Address
        [HttpPost]
        public async Task<IActionResult> CreateAddress([FromBody] Address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdAddress = await _addressRepository.CreateAsync(address);
            return CreatedAtAction(nameof(GetAddressById), new { id = createdAddress.Id }, createdAddress);
        }

        // PUT: api/v1/Address/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAddress(Guid id, [FromBody] Address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != address.Id)
            {
                return BadRequest("ID mismatch.");
            }
            var updateResult = await _addressRepository.UpdateByIdAsync(address);
            if (!updateResult)
            {
                return NotFound("Address not found.");
            }
            return NoContent();
        }

        // DELETE: api/v1/Address/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAddress(Guid id)
        {
            var deleteResult = await _addressRepository.DeleteByIdAsync(id);
            if (!deleteResult)
            {
                return NotFound("Address not found.");
            }
            return NoContent();
        }
    }
}
