using Ecommerce.Domain.src.ProductAggregate;
using Ecommerce.Domain.src.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Presentation.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageRepository _productImageRepository;

        public ProductImageController(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetImagesByProductId(Guid productId)
        {
            var images = await _productImageRepository.GetImagesByProductIdAsync(productId);
            return Ok(images);
        }

        [HttpGet("main/{productId}")]
        public async Task<IActionResult> GetMainImageForProduct(Guid productId)
        {
            var image = await _productImageRepository.GetMainImageForProductAsync(productId);
            if (image == null)
            {
                return NotFound();
            }
            return Ok(image);
        }

        [HttpGet("count/{productId}")]
        public async Task<IActionResult> GetImageCountByProductId(Guid productId)
        {
            var count = await _productImageRepository.GetImageCountByProductIdAsync(productId);
            return Ok(count);
        }

        [HttpDelete("delete/{productId}")]
        public async Task<IActionResult> DeleteImagesByProductId(Guid productId)
        {
            var success = await _productImageRepository.DeleteImagesByProductIdAsync(productId);
            if (success)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(ProductImage productImage)
        {
            var createdImage = await _productImageRepository.CreateAsync(productImage);
            return CreatedAtAction(nameof(GetImagesByProductId), new { productId = createdImage.ProductId }, createdImage);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductImage(Guid id, ProductImage productImage)
        {
            if (id != productImage.Id)
            {
                return BadRequest();
            }

            var success = await _productImageRepository.UpdateByIdAsync(productImage);
            if (success)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductImage(Guid id)
        {
            var success = await _productImageRepository.DeleteByIdAsync(id);
            if (success)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
