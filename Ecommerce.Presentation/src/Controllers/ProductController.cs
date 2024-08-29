using Ecommerce.Domain.src.ProductAggregate;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Service.src.ProductService;

namespace Ecommerce.Presentation.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductManagement _productManagement;

        public ProductController(IProductManagement productManagement)
        {
            _productManagement = productManagement;
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

    }
}
