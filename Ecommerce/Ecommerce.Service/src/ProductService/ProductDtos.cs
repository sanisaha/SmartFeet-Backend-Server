using Ecommerce.Domain.Enums;
using Ecommerce.Domain.src.Entities.ProductAggregate;
using Ecommerce.Domain.src.ProductAggregate;
using Ecommerce.Service.src.ProductColorService;
using Ecommerce.Service.src.ProductImageService;
using Ecommerce.Service.src.ProductSizeService;
using Ecommerce.Service.src.ReviewService;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.ProductService
{
    public class ProductReadDto : BaseReadDto<Product>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public Guid SubCategoryId { get; set; }
        public string? BrandName { get; set; }
        public int? Discount { get; set; }
        public int? OldPrice { get; set; }
        public bool IsFeatured { get; set; }
        public CategoryName CategoryName { get; set; }
        public SubCategoryName SubCategoryName { get; set; }
        public ICollection<ProductImageReadDto> ProductImages { get; set; }
        public ICollection<ProductSizeReadDto> ProductSizes { get; set; }
        public ICollection<ProductColorReadDto> ProductColors { get; set; }
        public ICollection<ReviewReadDto> Reviews { get; set; }


        public override void FromEntity(Product entity)
        {
            base.FromEntity(entity);
            Title = entity.Title;
            Description = entity.Description;
            Price = entity.Price;
            Stock = entity.Stock;
            SubCategoryId = entity.SubCategoryId;
            BrandName = entity.BrandName;
            Discount = entity.Discount;
            OldPrice = entity.OldPrice;
            IsFeatured = entity.IsFeatured;
            CategoryName = entity.CategoryName;
            SubCategoryName = entity.SubCategoryName;
            Reviews = entity.Reviews?.Select(x =>
            {
                var reviewDto = new ReviewReadDto();
                reviewDto.FromEntity(x);
                return reviewDto;
            }).ToList();
            ProductImages = entity.ProductImages?.Select(x =>
            {
                var productImageDto = new ProductImageReadDto();
                productImageDto.FromEntity(x);
                return productImageDto;
            }).ToList();
            ProductSizes = entity.ProductSizes?.Select(x =>
            {
                var productSizeDto = new ProductSizeReadDto();
                productSizeDto.FromEntity(x);
                return productSizeDto;
            }).ToList();
            ProductColors = entity.ProductColors?.Select(x =>
            {
                var productColorDto = new ProductColorReadDto();
                productColorDto.FromEntity(x);
                return productColorDto;
            }).ToList();
        }
    }
    public class ProductCreateDto : ICreateDto<Product>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public Guid SubCategoryId { get; set; }
        public string? BrandName { get; set; }
        public int? Discount { get; set; }
        public int? OldPrice { get; set; }
        public bool IsFeatured { get; set; }
        public CategoryName CategoryName { get; set; }
        public SubCategoryName SubCategoryName { get; set; }
        public ICollection<ProductImageCreateDto> ProductImages { get; set; }
        public ICollection<ProductSizeCreateDto> ProductSizes { get; set; }
        public ICollection<ProductColorCreateDto> ProductColors { get; set; }
        public Product CreateEntity()
        {
            return new Product
            {
                Title = Title,
                Description = Description,
                Price = Price,
                Stock = Stock,
                SubCategoryId = SubCategoryId,
                BrandName = BrandName,
                Discount = Discount,
                OldPrice = OldPrice,
                IsFeatured = IsFeatured,
                CategoryName = CategoryName,
                SubCategoryName = SubCategoryName,
                ProductImages = ProductImages.Select(x => x.CreateEntity()).ToList(),
                ProductSizes = ProductSizes.Select(x => x.CreateEntity()).ToList(),
                ProductColors = ProductColors.Select(x => x.CreateEntity()).ToList()
            };
        }
    }
    public class ProductUpdateDto : IUpdateDto<Product>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public Guid SubCategoryId { get; set; }
        public string? BrandName { get; set; }
        public int? Discount { get; set; }
        public int? OldPrice { get; set; }
        public bool IsFeatured { get; set; }
        public CategoryName CategoryName { get; set; }
        public SubCategoryName SubCategoryName { get; set; }
        public Product UpdateEntity(Product entity)
        {
            entity.Title = Title;
            entity.Description = Description;
            entity.Price = Price;
            entity.Stock = Stock;
            entity.SubCategoryId = SubCategoryId;
            entity.BrandName = BrandName;
            entity.Discount = Discount;
            entity.OldPrice = OldPrice;
            entity.IsFeatured = IsFeatured;
            entity.CategoryName = CategoryName;
            entity.SubCategoryName = SubCategoryName;
            return entity;
        }
    }
}