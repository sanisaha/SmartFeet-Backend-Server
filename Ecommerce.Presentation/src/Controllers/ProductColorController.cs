using Ecommerce.Domain.src.Entities.ProductAggregate;
using Ecommerce.Domain.src.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Presentation.src.Controllers

{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductColorController : ControllerBase
    {
        private readonly IProductColorRepository _productColorRepository;

        public ProductColorController(IProductColorRepository productColorRepository)
        {
            _productColorRepository = productColorRepository;
        }

        // GET: api/v1/productcolors/product/{productId}
        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetColorsByProductId(Guid productId)
        {
            var colors = await _productColorRepository.GetColorsByProductIdAsync(productId);
            return Ok(colors);
        }

        // GET: api/v1/productcolors/name/{colorName}
        [HttpGet("name/{colorName}")]
        public async Task<IActionResult> GetColorByName(string colorName)
        {
            var color = await _productColorRepository.GetColorByNameAsync(colorName);
            if (color == null)
            {
                return NotFound();
            }
            return Ok(color);
        }

        // POST: api/v1/productcolors
        [HttpPost]
        public async Task<IActionResult> CreateProductColor([FromBody] ProductColor productColor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdProductColor = await _productColorRepository.CreateAsync(productColor);
            return CreatedAtAction(nameof(GetColorsByProductId), new { productId = createdProductColor.ProductId }, createdProductColor);
        }

        // PUT: api/v1/productcolors/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductColor(Guid id, [FromBody] ProductColor productColor)
        {
            if (id != productColor.Id)
            {
                return BadRequest("ProductColor ID mismatch");
            }

            var result = await _productColorRepository.UpdateByIdAsync(productColor);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/v1/productcolors/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductColor(Guid id)
        {
            var result = await _productColorRepository.DeleteByIdAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
