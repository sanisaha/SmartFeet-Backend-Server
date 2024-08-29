using Ecommerce.Domain.src.Entities.ReviewAggregate;
using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Service.src.ReviewService;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Presentation.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewManagement _reviewManagement;

        public ReviewController(IReviewManagement reviewManagement)
        {
            _reviewManagement = reviewManagement;
        }

        // GET: api/v1/Review/Product/{productId}
        [HttpGet("Product/{productId:guid}")]
        public async Task<IActionResult> GetReviewsByProductId(Guid productId)
        {
            var reviews = await _reviewManagement.GetReviewsByProductIdAsync(productId);
            if (reviews == null)
            {
                return NotFound("No reviews found for this product.");
            }
            return Ok(reviews);
        }

        // GET: api/v1/Review/User/{userId}
        [HttpGet("User/{userId:guid}")]
        public async Task<IActionResult> GetReviewsByUserId(Guid userId)
        {
            var reviews = await _reviewManagement.GetReviewsByUserIdAsync(userId);
            if (reviews == null)
            {
                return NotFound("No reviews found for this user.");
            }
            return Ok(reviews);
        }

    }
}
