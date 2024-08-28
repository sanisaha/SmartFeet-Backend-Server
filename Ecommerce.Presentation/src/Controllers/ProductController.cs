using Ecommerce.Domain.src.ProductAggregate;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Domain.src.Interfaces;

namespace Ecommerce.Presentation.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var product = await _productRepository.GetAsync(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategory(Guid categoryId)
        {
            var products = await _productRepository.GetProductsByCategoryAsync(categoryId);
            return Ok(products);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchProducts([FromQuery] string title)
        {
            var products = await _productRepository.SearchProductsByTitleAsync(title);
            return Ok(products);
        }

        [HttpGet("price-range")]
        public async Task<IActionResult> GetProductsByPriceRange([FromQuery] decimal minPrice, [FromQuery] decimal maxPrice)
        {
            var products = await _productRepository.GetProductsByPriceRangeAsync(minPrice, maxPrice);
            return Ok(products);
        }

        // [HttpGet("top-selling")]
        // public async Task<IActionResult> GetTopSellingProducts([FromQuery] int count)
        // {
        //     var products = await _productRepository.GetTopSellingProductsAsync(count);
        //     return Ok(products);
        // }

        [HttpGet("in-stock")]
        public async Task<IActionResult> GetInStockProducts()
        {
            var products = await _productRepository.GetInStockProductsAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            var createdProduct = await _productRepository.CreateAsync(product);
            return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            var success = await _productRepository.UpdateByIdAsync(product);
            if (success)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var success = await _productRepository.DeleteByIdAsync(id);
            if (success)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
