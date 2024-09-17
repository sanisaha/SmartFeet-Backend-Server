using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.src.Entities.CartAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.CartItemService
{
    public interface ICartItemManagement : IBaseService<CartItem, CartItemReadDto, CartItemCreateDto, CartItemUpdateDto>
    {
        Task<List<CartItem>> GetCartItemsByCartId(Guid cartId);

    }
}