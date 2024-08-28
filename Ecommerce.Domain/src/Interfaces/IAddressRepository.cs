
using Ecommerce.Domain.src.AddressAggregate;
using Ecommerce.Domain.src.Interface;

namespace Ecommerce.Domain.src.Interfaces
{
    public interface IAddressRepository : IBaseRepository<Address>
    {
        Task<Address> GetAddressByIdAsync(Guid addressId);
        Task<IEnumerable<Address>> GetAllAddressesAsync();
    }
}