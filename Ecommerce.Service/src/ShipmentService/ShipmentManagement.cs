
using Ecommerce.Domain.src.Entities.ShipmentAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.ShipmentService
{
    public class ShipmentManagement : BaseService<Shipment, ShipmentReadDto, ShipmentCreateDto, ShipmentUpdateDto>, IShipmentManagement
    {
        public async Task<ShipmentCreateDto> CreateAsync(ShipmentCreateDto createDto)
        {
            throw new NotImplementedException();
        }

        public async Task<ShipmentUpdateDto> UpdateAsync(Guid id, ShipmentUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ShipmentReadDto>> GetShipmentsByOrderIdAsync(Guid orderId)
        {
            throw new NotImplementedException();
        }
    }
}