using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce.Domain.src.ProductAggregate;
using Ecommerce.Domain.src.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Domain.Enums;

namespace Ecommerce.Presentation.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductSizeController : ControllerBase
    {
        private readonly IProductSizeRepository _productSizeRepository;

        public ProductSizeController(IProductSizeRepository productSizeRepository)
        {
            _productSizeRepository = productSizeRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductSizeById(Guid id)
        {
            var productSize = await _productSizeRepository.GetAsync(ps => ps.Id == id);
            if (productSize == null)
            {
                return NotFound();
            }
            return Ok(productSize);
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetSizesByProductId(Guid productId)
        {
            var productSizes = await _productSizeRepository.GetSizesByProductIdAsync(productId);
            return Ok(productSizes);
        }

        [HttpGet("size-value/{sizeValue}")]
        public async Task<IActionResult> GetSizeByValue(SizeValue sizeValue)
        {
            var productSize = await _productSizeRepository.GetSizeByValueAsync(sizeValue);
            if (productSize == null)
            {
                return NotFound();
            }
            return Ok(productSize);
        }


        [HttpPost]
        public async Task<IActionResult> CreateProductSize(ProductSize productSize)
        {
            var createdProductSize = await _productSizeRepository.CreateAsync(productSize);
            return CreatedAtAction(nameof(GetProductSizeById), new { id = createdProductSize.Id }, createdProductSize);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductSize(Guid id, ProductSize productSize)
        {
            if (id != productSize.Id)
            {
                return BadRequest();
            }

            var success = await _productSizeRepository.UpdateByIdAsync(productSize);
            if (success)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductSize(Guid id)
        {
            var success = await _productSizeRepository.DeleteByIdAsync(id);
            if (success)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
