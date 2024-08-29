using Ecommerce.Domain.src.Auth;
using Ecommerce.Domain.src.Interface;
using Ecommerce.Domain.src.UserAggregate;
using System.Linq.Expressions;

namespace Ecommerce.Domain.src.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserByEmail(string email);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserByCredentialAsync(UserCredentials userCredentials);
        Task<bool> UpdatePasswordAsync(Guid userId, string newPassword);
        Task<User> GetAsync(Expression<Func<User, bool>>? filter = null, bool tracked = true);
    }
}