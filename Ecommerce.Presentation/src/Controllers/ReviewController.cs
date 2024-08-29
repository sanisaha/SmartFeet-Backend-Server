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

        // GET: api/v1/Review
        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            var reviews = await _reviewManagement.GetAllAsync();
            return Ok(reviews);
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

        // GET: api/v1/Review/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetReviewById(Guid id)
        {
            var review = await _reviewManagement.GetByIdAsync(id);
            if (review == null)
            {
                return NotFound("Review not found.");
            }
            return Ok(review);
        }

        // POST: api/v1/Review
        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] ReviewCreateDto review)
        {
            //need to convert Review to ReviewCreateDto
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdReview = await _reviewManagement.CreateAsync(review);
            return CreatedAtAction(nameof(GetReviewById), new { id = createdReview.Id }, createdReview);
        }

        // PUT: api/v1/Review/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateReview(Guid id, [FromBody] ReviewUpdateDto review)
        {
            //need to convert Review to ReviewUpdateDto
            var updatedReview = await _reviewManagement.UpdateAsync(id, review);
            if (updatedReview == null)
            {
                return NotFound("Review not found.");
            }
            return Ok(updatedReview);
        }

        // DELETE: api/v1/Review/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteReview(Guid id)
        {
            var deleteResult = await _reviewManagement.DeleteAsync(id);
            if (!deleteResult)
            {
                return NotFound("Review not found.");
            }
            return NoContent();
        }
    }
}
