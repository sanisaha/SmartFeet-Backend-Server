using System.Linq.Expressions;
using Ecommerce.Domain.Enums;
using Ecommerce.Domain.src.Entities.ProductAggregate;
using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Infrastructure.src.Database;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.src.Repository
{
    public class ProductColorRepository : BaseRepository<ProductColor>, IProductColorRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductColorRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductColor>> GetColorsByProductIdAsync(Guid productId)
        {
            return await _context.ProductColors
                .Where(pc => pc.ProductId == productId)
                .ToListAsync();
        }
    }
}
