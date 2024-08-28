using Ecommerce.Domain.src.UserAggregate;

namespace Ecommerce.Domain.src.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> CreateUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(Guid userId);
        Task<User> GetUserById(Guid userId);
        Task<User> GetUserByEmail(string email);
        Task<IEnumerable<User>> GetAllUsers();
    }
}