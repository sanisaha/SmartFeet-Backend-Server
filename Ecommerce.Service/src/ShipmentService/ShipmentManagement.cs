
using Ecommerce.Domain.src.Entities.ShipmentAggregate;
using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.ShipmentService
{
    public class ShipmentManagement : BaseService<Shipment, ShipmentReadDto, ShipmentCreateDto, ShipmentUpdateDto>, IShipmentManagement
    {
        private readonly IShipmentRepository _shipmentRepository;

        public ShipmentManagement(IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
        }
        public async Task<ShipmentReadDto> CreateAsync(ShipmentCreateDto createDto)
        {
            try
            {
                var shipment = createDto.CreateEntity();
                await _shipmentRepository.CreateAsync(shipment);
                var shipmentDto = new ShipmentReadDto();
                shipmentDto.FromEntity(shipment);
                return shipmentDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ShipmentUpdateDto> UpdateAsync(Guid id, ShipmentUpdateDto updateDto)
        {
            try
            {
                var shipment = await _shipmentRepository.GetAsync(s => s.Id == id);
                if (shipment == null)
                    throw new ArgumentException("Shipment not found.");

                shipment = updateDto.UpdateEntity(shipment);
                await _shipmentRepository.UpdateByIdAsync(shipment);
                return updateDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var shipment = await _shipmentRepository.GetAsync(s => s.Id == id);
                if (shipment == null)
                    throw new ArgumentException("Shipment not found.");

                await _shipmentRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ShipmentReadDto>> GetShipmentsByOrderIdAsync(Guid orderId)
        {
            try
            {
                var shipments = await _shipmentRepository.GetShipmentsByOrderIdAsync(orderId);
                return shipments.Select(s =>
                {
                    var shipmentDto = new ShipmentReadDto();
                    shipmentDto.FromEntity(s);
                    return shipmentDto;
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}