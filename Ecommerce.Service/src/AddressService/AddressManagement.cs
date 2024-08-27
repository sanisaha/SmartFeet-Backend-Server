
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.AddressService
{
    public class AddressManagement : BaseService<Address, AddressReadDto, AddressCreateDto, AddressUpdateDto>, IAddressManagement
    {
        public Task<AddressCreateDto> CreateAsync(AddressCreateDto createDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<AddressReadDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<AddressUpdateDto> UpdateAsync(Guid id, AddressUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}