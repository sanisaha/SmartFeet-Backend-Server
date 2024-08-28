using System.Linq.Expressions;
using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Domain.src.UserAggregate;
using Ecommerce.Infrastructure.src.Database;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.src.Repository
{
    public class UserRepo : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<User> _users;
        public UserRepo(ApplicationDbContext context)
        {
            _context = context;
            _users = context.Users;
        }
        public Task<User> CreateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _users.ToListAsync();
        }

        public Task<User> GetAsync(Expression<Func<User, bool>>? filter = null, bool tracked = true)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateByIdAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}