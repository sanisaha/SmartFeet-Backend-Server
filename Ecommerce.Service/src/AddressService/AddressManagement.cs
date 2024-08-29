
using Ecommerce.Domain.src.Interface;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.AddressService
{
    public class AddressManagement : BaseService<Address, AddressReadDto, AddressCreateDto, AddressUpdateDto>, IAddressManagement
    {
        public AddressManagement(IBaseRepository<Address> repo) : base(repo)
        {
        }

        public async Task<AddressCreateDto> CreateAsync(AddressCreateDto createDto)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<AddressReadDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<AddressUpdateDto> UpdateAsync(Guid id, AddressUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}