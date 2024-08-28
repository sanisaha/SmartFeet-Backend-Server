using Ecommerce.Domain.src.Interface;
using Ecommerce.Domain.src.UserAggregate;

namespace Ecommerce.Domain.src.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserByEmail(string email);
        Task<IEnumerable<User>> GetAllUsers();
    }
}