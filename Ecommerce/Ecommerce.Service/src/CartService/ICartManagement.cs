using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.src.Entities.CartAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.CartService
{
    public interface ICartManagement : IBaseService<Cart, CartReadDto, CartCreateDto, CartUpdateDto>
    {
        Task<Cart> GetCartByUserId(Guid userId);
    }
}