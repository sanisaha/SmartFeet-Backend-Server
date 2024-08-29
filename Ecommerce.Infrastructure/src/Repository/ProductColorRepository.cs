using System.Linq.Expressions;
using Ecommerce.Domain.Enums;
using Ecommerce.Domain.src.Entities.ProductAggregate;
using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Infrastructure.src.Database;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.src.Repository
{
    public class ProductColorRepository : IProductColorRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductColorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductColor> CreateAsync(ProductColor entity)
        {
            _context.ProductColors.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateByIdAsync(ProductColor entity)
        {
            _context.ProductColors.Update(entity);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var productColor = await _context.ProductColors.FindAsync(id);
            if (productColor == null)
            {
                return false;
            }

            _context.ProductColors.Remove(productColor);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<ProductColor> GetAsync(Expression<Func<ProductColor, bool>>? filter = null, bool tracked = true)
        {
            IQueryable<ProductColor> query = _context.ProductColors;

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

        public async Task<IEnumerable<ProductColor>> GetColorsByProductIdAsync(Guid productId)
        {
            return await _context.ProductColors
                .Where(pc => pc.ProductId == productId)
                .ToListAsync();
        }

        public async Task<ProductColor> GetColorByNameAsync(string colorName)
        {
            // Use Enum.Parse or try to match enum values instead of using Equals
            if (Enum.TryParse(typeof(ColorName), colorName, true, out var colorEnum))
            {
                return await _context.ProductColors
                    .Where(pc => pc.ColorName == (ColorName)colorEnum)
                    .FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<IEnumerable<ProductColor>> GetAllAsync()
        {
            return await _context.ProductColors.ToListAsync();
        }
    }
}
