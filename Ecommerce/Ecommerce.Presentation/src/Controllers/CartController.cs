using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Presentation.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartController : AppController<Cart, CartReadDto, CartCreateDto, CartUpdateDto>
    {
        private readonly ICartManagement _cartManagement;

        public CartController(ICartManagement cartManagement) : base(cartManagement)
        {
            _cartManagement = cartManagement;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetCartByUserId(Guid userId)
        {
            var cart = await _cartManagement.GetCartByUserId(userId);
            return Ok(cart);
        }
    }
}