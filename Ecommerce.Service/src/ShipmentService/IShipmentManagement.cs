
using Ecommerce.Domain.src.Entities.ShipmentAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.ShipmentService
{
    public interface IShipmentManagement : IBaseService<Shipment, ShipmentReadDto, ShipmentCreateDto, ShipmentUpdateDto>
    {
        Task<ShipmentReadDto> CreateAsync(ShipmentCreateDto createDto);
        Task<ShipmentUpdateDto> UpdateAsync(Guid id, ShipmentUpdateDto updateDto);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<ShipmentReadDto>> GetShipmentsByOrderIdAsync(Guid orderId);
    }
}