
using System.Linq.Expressions;
using Ecommerce.Domain.src.ProductAggregate;
using Ecommerce.Domain.src.Interfaces;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Infrastructure.src.Database;

namespace Ecommerce.Infrastructure.src.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Product> CreateAsync(Product entity)
        {
            var subCategoryExists = await _context.SubCategories.AnyAsync(c => c.Id == entity.SubCategoryId);
            if (!subCategoryExists)
            {
                throw new Exception("SubCategory does not exist");
            }
            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(Guid SubcategoryId)
        {
            return await _context.Products
                .Where(p => p.SubCategoryId == SubcategoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchProductsByTitleAsync(string title)
        {
            return await _context.Products
                .Where(p => p.Title.Contains(title))
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            return await _context.Products
                .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
                .ToListAsync();
        }

        // public async Task<IEnumerable<Product>> GetTopSellingProductsAsync(int count)
        // {
        //     return await _context.Products
        //         .OrderByDescending(p => p.SalesCount)
        //         .Take(count)
        //         .ToListAsync();
        // }

        public async Task<IEnumerable<Product>> GetInStockProductsAsync()
        {
            return await _context.Products
                .Where(p => p.Stock > 0)
                .ToListAsync();
        }

        public Task<IEnumerable<Product>> GetTopSellingProductsAsync(int count)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
