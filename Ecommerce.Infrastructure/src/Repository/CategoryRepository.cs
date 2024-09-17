using Ecommerce.Domain.Enums;
using Ecommerce.Domain.src.CategoryAggregate;
using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Domain.src.Model;
using Ecommerce.Domain.src.Shared;
using Ecommerce.Infrastructure.src.Database;
using Ecommerce.Service.src.CategoryService;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecommerce.Infrastructure.src.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<PaginatedResult<Category>> GetAllAsync(PaginationOptions paginationOptions)
        {
            var totalEntity = await _context.Categories.CountAsync();
            IQueryable<Category> query = _context.Categories;
            var entities = await query
            .Include(c => c.SubCategories)
            .ThenInclude(sc => sc.Products)
                //.Skip(paginationOptions.Page)
                //.Take(paginationOptions.PerPage)
                .ToListAsync();

            return new PaginatedResult<Category>
            {
                Items = entities,
                TotalPages = (int)Math.Ceiling(totalEntity / (double)paginationOptions.PerPage),
                CurrentPage = paginationOptions.Page,
            };


        }

        public async Task<IEnumerable<Category>> GetCategoryByIdAsync(Guid userId)
        {
            return await _context.Categories.Where(c => c.Id == userId).ToListAsync();
        }
        public async Task<Category?> GetCategoryByNameAsync(string categoryName)
        {
            if (Enum.TryParse(categoryName, out CategoryName categoryEnum))
            {
                return await _context.Categories.FirstOrDefaultAsync(c => c.CategoryName == categoryEnum);
            }
            return null;
        }
    }
}
