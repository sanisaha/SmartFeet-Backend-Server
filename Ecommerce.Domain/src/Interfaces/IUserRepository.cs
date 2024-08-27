using Ecommerce.Domain.src.UserAggregate;

namespace Ecommerce.Domain.src.Interfaces
{
    public interface IUserRepository
    {
        public bool CreateUser(User user);
        public bool UpdateUser(User user);
        public bool DeleteUser(Guid userId);
        public User GetUserById(Guid userId);
        public User GetUserByEmail(string email);
        public IEnumerable<User> GetAllUsers();
    }
}