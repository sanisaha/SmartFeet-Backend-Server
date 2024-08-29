using Ecommerce.Domain.src.Entities.UserAggregate;
using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Infrastructure.src.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecommerce.Infrastructure.src.Repository
{
    public class UserAddressRepository : IUserAddressRepository
    {
        private readonly ApplicationDbContext _context;

        public UserAddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserAddress> CreateAsync(UserAddress entity)
        {
            await _context.UserAddress.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateByIdAsync(UserAddress entity)
        {
            _context.UserAddress.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var userAddress = await _context.UserAddress.FindAsync(id);
            if (userAddress == null) return false;

            _context.UserAddress.Remove(userAddress);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<UserAddress> GetAsync(Expression<Func<UserAddress, bool>>? filter = null, bool tracked = true)
        {
            IQueryable<UserAddress> query = _context.UserAddress;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<UserAddress>> GetUserAddressesByUserId(Guid userId)
        {
            return await _context.UserAddress.Where(ua => ua.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<UserAddress>> GetAllAsync()
        {
            return await _context.UserAddress.ToListAsync();
        }
    }
}
