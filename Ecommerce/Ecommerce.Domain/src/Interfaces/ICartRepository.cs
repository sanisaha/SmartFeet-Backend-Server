using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.src.Entities.CartAggregate;
using Ecommerce.Domain.src.Interface;

namespace Ecommerce.Domain.src.Interfaces
{
    public interface ICartRepository : IBaseRepository<Cart>
    {
        Task<Cart> GetCartByUserId(Guid userId);
    }
}