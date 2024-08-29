using System.Linq.Expressions;
using Ecommerce.Domain.src.ProductAggregate;
using Ecommerce.Domain.src.Interfaces;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Infrastructure.src.Database;
using Ecommerce.Domain.Enums;

namespace Ecommerce.Infrastructure.Repositories
{
    public class ProductSizeRepository : IProductSizeRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductSizeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductSize> CreateAsync(ProductSize entity)
        {
            _context.ProductSizes.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateByIdAsync(ProductSize entity)
        {
            _context.ProductSizes.Update(entity);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var productSize = await _context.ProductSizes.FindAsync(id);
            if (productSize == null)
            {
                return false;
            }

            _context.ProductSizes.Remove(productSize);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<ProductSize> GetAsync(Expression<Func<ProductSize, bool>>? filter = null, bool tracked = true)
        {
            IQueryable<ProductSize> query = _context.ProductSizes;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProductSize>> GetSizesByProductIdAsync(Guid productId)
        {
            return await _context.ProductSizes
                .Where(ps => ps.ProductId == productId)
                .ToListAsync();
        }

        public async Task<ProductSize> GetSizeByNameAsync(SizeValue sizeValue)
        {
            return await _context.ProductSizes
                .FirstOrDefaultAsync(ps => ps.SizeValue == sizeValue);
        }

        public Task<ProductSize> GetSizeByValueAsync(SizeValue sizeValue)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductSize>> GetAllAsync()
        {
            return await _context.ProductSizes.ToListAsync();
        }
    }
}
