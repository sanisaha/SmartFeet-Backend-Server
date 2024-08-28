using System.Linq.Expressions;
using Ecommerce.Domain.src.Entities.ShipmentAggregate;
using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Infrastructure.src.Database;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.src.Repository
{
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly ApplicationDbContext _context;

        public ShipmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Shipment> CreateAsync(Shipment entity)
        {
            await _context.Shipments.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateByIdAsync(Shipment entity)
        {
            _context.Shipments.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var shipment = await _context.Shipments.FindAsync(id);
            if (shipment == null) return false;

            _context.Shipments.Remove(shipment);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Shipment> GetAsync(Expression<Func<Shipment, bool>>? filter = null, bool tracked = true)
        {
            IQueryable<Shipment> query = _context.Shipments;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Shipment>> GetAllShipments()
        {
            return await _context.Shipments.ToListAsync();
        }

        public async Task<IEnumerable<Shipment>> GetShipmentsByOrderIdAsync(Guid orderId)
        {
            return await _context.Shipments.Where(s => s.Order.Id == orderId).ToListAsync();
        }
    }
}