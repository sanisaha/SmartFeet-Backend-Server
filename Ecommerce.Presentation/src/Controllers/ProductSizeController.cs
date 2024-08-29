using Microsoft.AspNetCore.Mvc;
using Ecommerce.Domain.Enums;
using Ecommerce.Service.src.ProductSizeService;

namespace Ecommerce.Presentation.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductSizeController : ControllerBase
    {
        private readonly IProductSizeManagement _productSizeManagement;

        public ProductSizeController(IProductSizeManagement productSizeManagement)
        {
            _productSizeManagement = productSizeManagement;
        }

        [HttpGet("Product/{productId:guid}")]
        public async Task<IActionResult> GetSizesByProductIdAsync(Guid productId)
        {
            var sizes = await _productSizeManagement.GetSizesByProductIdAsync(productId);
            if (sizes == null)
            {
                return NotFound("No sizes found for this product.");
            }
            return Ok(sizes);
        }

        [HttpGet("Size/{sizeValue}")]
        public async Task<IActionResult> GetSizeByValueAsync(SizeValue sizeValue)
        {
            var size = await _productSizeManagement.GetSizeByValueAsync(sizeValue);
            if (size == null)
            {
                return NotFound("No size found for this value.");
            }
            return Ok(size);
        }
    }
}
