using Ecommerce.Domain.src.AddressAggregate;
using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Infrastructure.src.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecommerce.Infrastructure.src.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _context;

        public AddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Address> CreateAsync(Address entity)
        {
            await _context.Addresses.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateByIdAsync(Address entity)
        {
            _context.Addresses.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            if (address == null) return false;

            _context.Addresses.Remove(address);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Address> GetAsync(Expression<Func<Address, bool>>? filter = null, bool tracked = true)
        {
            IQueryable<Address> query = _context.Addresses;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Address> GetAddressByIdAsync(Guid addressId)
        {
            return await _context.Addresses.FirstOrDefaultAsync(a => a.Id == addressId);
        }

        public async Task<IEnumerable<Address>> GetAllAddressesAsync()
        {
            return await _context.Addresses.ToListAsync();
        }
    }
}
