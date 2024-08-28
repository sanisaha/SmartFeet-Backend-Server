using Ecommerce.Domain.src.Entities.UserAggregate;

namespace Ecommerce.Domain.src.Interfaces
{
    public interface IUserAddressRepository
    {
        Task<bool> CreateUserAdAsync(UserAddress userAddress);
        Task<bool> UpdateUserAddressAsync(UserAddress userAddress);
        Task<bool> DeleteUserAddressAsync(Guid userId, Guid addressId);
        Task<UserAddress> GetUserAddressAsync(Guid userId, Guid addressId);
        Task<IEnumerable<UserAddress>> GetUserAddressesByUserId(Guid userId);
    }
}