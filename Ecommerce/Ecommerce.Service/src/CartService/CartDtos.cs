using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Service.src.CartService
{
    public class CartReadDto : BaseReadDto<Cart>
    {
        public Guid? UserId { get; set; }
        public virtual ICollection<CartItemReadDto> CartItems { get; set; }

        public override void FromEntity(Cart entity)
        {
            UserId = entity.UserId;
            CartItems = entity.CartItems.Select(item => new CartItemReadDto().FromEntity(item)).ToList();
            base.FromEntity(entity);
        }
    }

    public class CartCreateDto : ICreateDto<Cart>
    {
        public Guid? UserId { get; set; }
        public IEnumerable<CartItemCreateDto> CartItems { get; set; }

        public Cart CreateEntity()
        {
            return new Cart
            {
                UserId = UserId,
                CartItems = CartItems.Select(item => item.CreateEntity()).ToList()
            };
        }
    }

    public class CartUpdateDto : IUpdateDto<Cart>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public IEnumerable<CartItemUpdateDto> CartItems { get; set; }

        public Cart UpdateEntity(Cart entity)
        {
            entity.UserId = UserId;
            entity.CartItems = CartItems.Select(item => item.UpdateEntity()).ToList();
            return entity;
        }
    }
}