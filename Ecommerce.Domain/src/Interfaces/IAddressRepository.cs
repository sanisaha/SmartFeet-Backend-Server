
using Ecommerce.Domain.src.AddressAggregate;

namespace Ecommerce.Domain.src.Interfaces
{
    public interface IAddressRepository
    {
        public bool CreateAddress(Address address);
        public bool UpdateAddress(Address address);
        public bool DeleteAddress(Guid addressId);
        public Address GetAddressById(Guid addressId);
        public IEnumerable<Address> GetAllAddresses();
    }
}