using System.Linq.Expressions;
using Ecommerce.Domain.src.ProductAggregate;
using Ecommerce.Domain.src.Interfaces;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Infrastructure.src.Database;

namespace Ecommerce.Infrastructure.Repositories
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductImageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductImage> CreateAsync(ProductImage entity)
        {
            _context.ProductImages.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateByIdAsync(ProductImage entity)
        {
            _context.ProductImages.Update(entity);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var productImage = await _context.ProductImages.FindAsync(id);
            if (productImage == null)
            {
                return false;
            }

            _context.ProductImages.Remove(productImage);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<ProductImage> GetAsync(Expression<Func<ProductImage, bool>>? filter = null, bool tracked = true)
        {
            IQueryable<ProductImage> query = _context.ProductImages;

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

        public async Task<IEnumerable<ProductImage>> GetImagesByProductIdAsync(Guid productId)
        {
            return await _context.ProductImages
                .Where(pi => pi.ProductId == productId)
                .ToListAsync();
        }

        public async Task<ProductImage> GetMainImageForProductAsync(Guid productId)
        {
            return await _context.ProductImages
                .Where(pi => pi.ProductId == productId && pi.IsPrimary)
                .FirstOrDefaultAsync();
        }

        public async Task<int> GetImageCountByProductIdAsync(Guid productId)
        {
            return await _context.ProductImages
                .CountAsync(pi => pi.ProductId == productId);
        }

        public async Task<bool> DeleteImagesByProductIdAsync(Guid productId)
        {
            var images = await _context.ProductImages
                .Where(pi => pi.ProductId == productId)
                .ToListAsync();

            if (images.Count == 0)
            {
                return false;
            }

            _context.ProductImages.RemoveRange(images);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
