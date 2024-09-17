
using System.Linq.Expressions;
using Ecommerce.Domain.src.ProductAggregate;
using Ecommerce.Domain.src.Interfaces;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Infrastructure.src.Database;
using Ecommerce.Domain.src.Shared;
using Ecommerce.Domain.src.Model;

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

        public override async Task<PaginatedResult<Product>> GetAllAsync(PaginationOptions paginationOptions)
        {
            var totalEntity = await _context.Products.CountAsync();
            IQueryable<Product> query = _context.Products;
            var entities = await query
            .Include(p => p.Reviews)
            .Include(p => p.ProductColors)
            .Include(p => p.ProductSizes)
            .Include(p => p.ProductImages)
                .ToListAsync();

            return new PaginatedResult<Product>
            {
                Items = entities,
                TotalPages = (int)Math.Ceiling(totalEntity / (double)paginationOptions.PerPage),
                CurrentPage = paginationOptions.Page,
            };
        }

        public override async Task<Product> GetAsync(Guid id)
        {
            return await _context.Products
                .Include(p => p.Reviews)
                .Include(p => p.ProductColors)
                .Include(p => p.ProductSizes)
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.Id == id);
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

        public async Task<PaginatedResult<Product>> GetFilteredProductsAsync(PaginationOptions paginationOptions, FilterOptions filterOptions)
        {
            IQueryable<Product> query = _context.Products
                .Include(p => p.Reviews)
                .Include(p => p.ProductColors)
                .Include(p => p.ProductSizes)
                .Include(p => p.ProductImages);

            // Apply filters
            if (!string.IsNullOrEmpty(filterOptions.Category?.ToString()))
                query = query.Where(p => p.CategoryName == filterOptions.Category);

            if (!string.IsNullOrEmpty(filterOptions.SubCategory?.ToString()))
                query = query.Where(p => p.SubCategoryName == filterOptions.SubCategory);

            if (!string.IsNullOrEmpty(filterOptions.Brand))
                query = query.Where(p => p.BrandName == filterOptions.Brand);

            if (!string.IsNullOrEmpty(filterOptions.Size?.ToString()))
                query = query.Where(p => p.ProductSizes.Any(s => s.SizeValue == filterOptions.Size));

            var totalEntity = await query.CountAsync();

            // Pagination logic
            var entities = await query
                .Skip((paginationOptions.Page - 1) * paginationOptions.PerPage)
                .Take(paginationOptions.PerPage)
                .ToListAsync();

            return new PaginatedResult<Product>
            {
                Items = entities,
                TotalPages = (int)Math.Ceiling(totalEntity / (double)paginationOptions.PerPage),
                CurrentPage = paginationOptions.Page,
            };
        }
    }
}
