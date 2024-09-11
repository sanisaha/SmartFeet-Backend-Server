using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.src.Entities.CartAggregate;
using Ecommerce.Service.src.CartItemService;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Presentation.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartItemController : AppController<CartItem, CartItemReadDto, CartItemCreateDto, CartItemUpdateDto>
    {
        private readonly ICartItemManagement _cartItemManagement;

        public CartItemController(ICartItemManagement cartItemManagement) : base(cartItemManagement)
        {
            _cartItemManagement = cartItemManagement;
        }

        [HttpGet("cart/{cartId}")]
        public async Task<IActionResult> GetCartItemsByCartId(Guid cartId)
        {
            var cartItems = await _cartItemManagement.GetCartItemsByCartId(cartId);
            return Ok(cartItems);
        }
    }
}