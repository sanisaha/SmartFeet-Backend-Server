using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.src.ProductAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.ProductImageService
{
    public class ProductImageReadDto : BaseReadDto<ProductImage>
    {
        public Guid ProductId { get; set; }
        public string ImageURL { get; set; }

        public override void FromEntity(ProductImage entity)
        {
            base.FromEntity(entity);
            ProductId = entity.ProductId;
            ImageURL = entity.ImageURL;
        }
    }
    public class ProductImageCreateDto : ICreateDto<ProductImage>
    {
        public Guid ProductId { get; set; }
        public string ImageURL { get; set; }
        public ProductImage CreateEntity()
        {
            return new ProductImage
            {
                ProductId = ProductId,
                ImageURL = ImageURL
            };
        }
    }
    public class ProductImageUpdateDto : IUpdateDto<ProductImage>
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string ImageURL { get; set; }
        public ProductImage UpdateEntity(ProductImage entity)
        {
            entity.ProductId = ProductId;
            entity.ImageURL = ImageURL;
            return entity;
        }
    }
}