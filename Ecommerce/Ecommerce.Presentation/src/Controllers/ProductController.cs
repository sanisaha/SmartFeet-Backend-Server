using Ecommerce.Domain.src.ProductAggregate;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Service.src.ProductService;
using Microsoft.AspNetCore.Authorization;
using Ecommerce.Domain.src.Model;

namespace Ecommerce.Presentation.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : AppController<Product, ProductReadDto, ProductCreateDto, ProductUpdateDto>
    {
        private readonly IProductManagement _productManagement;

        public ProductController(IProductManagement productManagement) : base(productManagement)
        {
            _productManagement = productManagement;
        }

        public override async Task<ActionResult<ProductReadDto>> GetByIdAsync(Guid id)
        {
            return await base.GetByIdAsync(id);
        }

        //[Authorize(Roles = "Admin")]
        public override async Task<ActionResult<ProductReadDto>> CreateAsync(ProductCreateDto entity)
        {
            return await base.CreateAsync(entity);
        }

        //[Authorize(Roles = "Admin")]
        public override async Task<ActionResult<ProductReadDto>> UpdateAsync(Guid id, ProductUpdateDto entity)
        {
            return await base.UpdateAsync(id, entity);
        }

        //[Authorize(Roles = "Admin")]
        public override async Task<ActionResult> DeleteAsync(Guid id)
        {
            return await base.DeleteAsync(id);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategory(Guid categoryId)
        {
            var products = await _productManagement.GetProductsByCategoryAsync(categoryId);
            return Ok(products);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchProducts([FromQuery] string title)
        {
            var products = await _productManagement.SearchProductsByTitleAsync(title);
            return Ok(products);
        }

        [HttpGet("price-range")]
        public async Task<IActionResult> GetProductsByPriceRange([FromQuery] decimal minPrice, [FromQuery] decimal maxPrice)
        {
            var products = await _productManagement.GetProductsByPriceRangeAsync(minPrice, maxPrice);
            return Ok(products);
        }

        // [HttpGet("top-selling")]
        // public async Task<IActionResult> GetTopSellingProducts([FromQuery] int count)
        // {
        //     var products = await _productManagement.GetTopSellingProductsAsync(count);
        //     return Ok(products);
        // }

        [HttpGet("in-stock")]
        public async Task<IActionResult> GetInStockProducts()
        {
            var products = await _productManagement.GetInStockProductsAsync();
            return Ok(products);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetFilteredProducts([FromQuery] PaginationOptions paginationOptions, [FromQuery] FilterOptions filterOptions)
        {
            var products = await _productManagement.GetFilteredProductsAsync(paginationOptions, filterOptions);
            return Ok(products);
        }

        [HttpGet("subcategory/{subcategoryId}")]
        public async Task<IActionResult> GetProductsBySubcategory(Guid subcategoryId)
        {
            var products = await _productManagement.GetProductsBySubcategoryAsync(subcategoryId);
            return Ok(products);
        }

        [HttpGet("new-arrival")]
        public async Task<IActionResult> GetProductsByNewArrival()
        {
            var products = await _productManagement.GetProductsByNewArrivalAsync();
            return Ok(products);
        }

        [HttpGet("featured")]
        public async Task<IActionResult> GetProductsByFeatured()
        {
            var products = await _productManagement.GetProductsByFeaturedAsync();
            return Ok(products);
        }

    }
}
