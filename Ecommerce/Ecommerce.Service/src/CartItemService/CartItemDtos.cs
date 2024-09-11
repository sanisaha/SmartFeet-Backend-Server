using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.src.Entities.CartAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.CartItemService
{
    public class CartItemReadDto : BaseReadDto<CartItem>
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Guid CartId { get; set; }

        public override void FromEntity(CartItem entity)
        {
            base.FromEntity(entity);
            ProductId = entity.ProductId;
            Quantity = entity.Quantity;
            Price = entity.Price;
            CartId = entity.CartId;
        }
    }

    public class CartItemCreateDto : ICreateDto<CartItem>
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Guid CartId { get; set; }

        public CartItem CreateEntity()
        {
            return new CartItem
            {
                ProductId = ProductId,
                Quantity = Quantity,
                Price = Price,
                CartId = CartId
            };
        }
    }

    public class CartItemUpdateDto : IUpdateDto<CartItem>
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Guid CartId { get; set; }

        public CartItem UpdateEntity(CartItem entity)
        {
            entity.ProductId = ProductId;
            entity.Quantity = Quantity;
            entity.Price = Price;
            entity.CartId = CartId;
            return entity;
        }
    }
}