using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Service.src.CartService
{
    public class ICartManagement : IBaseService<Cart, CartReadDto, CartCreateDto, CartUpdateDto>
    {
        Task<Cart> GetCartByUserId(Guid userId);
    }
}