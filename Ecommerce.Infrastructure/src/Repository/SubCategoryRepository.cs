using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.Enums;
using Ecommerce.Domain.src.Entities.SubCategoryAggregate;
using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Domain.src.Model;
using Ecommerce.Domain.src.Shared;
using Ecommerce.Infrastructure.src.Database;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.src.Repository
{
    public class SubCategoryRepository : BaseRepository<SubCategory>, ISubCategoryRepository
    {
        public readonly ApplicationDbContext _context;
        public SubCategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<SubCategory> CreateAsync(SubCategory entity)
        {
            var categoryExist = await _context.Categories.FindAsync(entity.CategoryId);
            if (categoryExist == null)
            {
                throw new Exception("Category does not exist");
            }
            await _context.SubCategories.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public override async Task<PaginatedResult<SubCategory>> GetAllAsync(PaginationOptions paginationOptions)
        {
            var totalEntity = await _context.SubCategories.CountAsync();
            IQueryable<SubCategory> query = _context.SubCategories;
            var entities = await query
            .Include(c => c.Products)
            .ToListAsync();

            return new PaginatedResult<SubCategory>
            {
                Items = entities,
                TotalPages = (int)Math.Ceiling(totalEntity / (double)paginationOptions.PerPage),
                CurrentPage = paginationOptions.Page,
            };
        }


        public async Task<IEnumerable<SubCategory>> GetSubCategoryByIdAsync(Guid userId)
        {
            return await Task.FromResult(_context.SubCategories.Where(x => x.Id == userId));
        }
        public async Task<SubCategory?> GetSubCategoryByNameAndIdAsync(string subCategoryName, Guid categoryId)
        {
            if (Enum.TryParse(subCategoryName, out SubCategoryName subCategoryEnum))
            {
                return await _context.SubCategories.FirstOrDefaultAsync(c => c.SubCategoryName == subCategoryEnum && c.CategoryId == categoryId);
            }
            return null;
        }

    }
}