using Ecommerce.Domain.src.ProductAggregate;
using Ecommerce.Domain.src.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Service.src.ProductImageService;

namespace Ecommerce.Presentation.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageManagement _productImageManagement;

        public ProductImageController(IProductImageManagement productImageManagement)
        {
            _productImageManagement = productImageManagement;
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<IEnumerable<ProductImageReadDto>>> GetImagesByProductIdAsync(Guid productId)
        {
            try
            {
                var entities = await _productImageManagement.GetImagesByProductIdAsync(productId);
                return Ok(entities);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error getting entities!.");
            }
        }

        [HttpGet("main/{productId}")]
        public async Task<ActionResult<ProductImageReadDto>> GetMainImageForProductAsync(Guid productId)
        {
            try
            {
                var entity = await _productImageManagement.GetMainImageForProductAsync(productId);
                return Ok(entity);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error getting entity!.");
            }
        }

        [HttpGet("count/{productId}")]
        public async Task<ActionResult<int>> GetImageCountByProductIdAsync(Guid productId)
        {
            try
            {
                var count = await _productImageManagement.GetImageCountByProductIdAsync(productId);
                return Ok(count);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error getting entity!.");
            }
        }

        [HttpDelete("delete/{productId}")]
        public async Task<ActionResult<bool>> DeleteImagesByProductIdAsync(Guid productId)
        {
            try
            {
                var result = await _productImageManagement.DeleteImagesByProductIdAsync(productId);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error getting entity!.");
            }
        }
    }
}
