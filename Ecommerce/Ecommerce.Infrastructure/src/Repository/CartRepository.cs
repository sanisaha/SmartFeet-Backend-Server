using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.src.Repository
{
    public class CartRepository : BaseRepository<Cart>, ICartRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CartRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Cart> GetCartByUserId(Guid userId)
        {
            return await _dbContext.Carts.FirstOrDefaultAsync(x => x.UserId == userId);
        }
    }
}