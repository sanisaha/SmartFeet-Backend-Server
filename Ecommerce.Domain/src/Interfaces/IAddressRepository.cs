
using Ecommerce.Domain.src.AddressAggregate;

namespace Ecommerce.Domain.src.Interfaces
{
    public interface IAddressRepository
    {
        Task<bool> CreateAddressAsync(Address address);
        Task<bool> UpdateAddressAsync(Address address);
        Task<bool> DeleteAddressAsync(Guid addressId);
        Task<Address> GetAddressByIdAsync(Guid addressId);
        Task<IEnumerable<Address>> GetAllAddressesAsync();
    }
}