using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.src.Entities.SubCategoryAggregate;
using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Infrastructure.src.Database;

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


        public async Task<IEnumerable<SubCategory>> GetSubCategoryByIdAsync(Guid userId)
        {
            return await Task.FromResult(_context.SubCategories.Where(x => x.Id == userId));
        }

    }
}