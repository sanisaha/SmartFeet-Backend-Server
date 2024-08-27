using Ecommerce.Domain.src.Entities.UserAggregate;

namespace Ecommerce.Domain.src.Interfaces
{
    public interface IUserAddressRepository
    {
        public bool CreateUserAd(UserAddress userAddress);
        public bool UpdateUserAddress(UserAddress userAddress);
        public bool DeleteUserAddress(Guid userId, Guid addressId);
        public UserAddress GetUserAddress(Guid userId, Guid addressId);
        public IEnumerable<UserAddress> GetUserAddressesByUserId(Guid userId);
    }
}