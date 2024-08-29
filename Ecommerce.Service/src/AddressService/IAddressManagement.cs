using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.AddressService
{
    public interface IAddressManagement : IBaseService<Address, AddressReadDto, AddressCreateDto, AddressUpdateDto>
    {
        Task<AddressCreateDto> CreateAsync(AddressCreateDto createDto);
        Task<AddressUpdateDto> UpdateAsync(Guid id, AddressUpdateDto updateDto);
        Task<AddressReadDto> GetByIdAsync(Guid id);
        public Task DeleteAsync(Guid id);

    }
}