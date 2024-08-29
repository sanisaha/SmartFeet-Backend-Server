using Ecommerce.Domain.Enums;
using Ecommerce.Domain.src.ProductAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.ProductSizeService
{
    public class ProductSizeReadDto : BaseReadDto<ProductSize>
    {
        public Guid ProductId { get; set; }
        public SizeValue SizeValue { get; set; }
        public int StockQuantity { get; set; }

        public override void FromEntity(ProductSize entity)
        {
            base.FromEntity(entity);
            ProductId = entity.ProductId;
            SizeValue = entity.SizeValue;
            StockQuantity = entity.StockQuantity;
        }
    }
    public class ProductSizeCreateDto : ICreateDto<ProductSize>
    {
        public Guid ProductId { get; set; }
        public SizeValue SizeValue { get; set; }
        public int StockQuantity { get; set; }
        public ProductSize CreateEntity()
        {
            return new ProductSize
            {
                ProductId = ProductId,
                SizeValue = SizeValue,
                StockQuantity = StockQuantity
            };
        }
    }
    public class ProductSizeUpdateDto : IUpdateDto<ProductSize>
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public SizeValue SizeValue { get; set; }
        public int StockQuantity { get; set; }
        public ProductSize UpdateEntity(ProductSize entity)
        {
            entity.ProductId = ProductId;
            entity.SizeValue = SizeValue;
            entity.StockQuantity = StockQuantity;
            return entity;
        }
    }
}