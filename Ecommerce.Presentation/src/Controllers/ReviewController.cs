using Ecommerce.Domain.src.Entities.ReviewAggregate;
using Ecommerce.Domain.src.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Presentation.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        // GET: api/v1/Review
        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            var reviews = await _reviewRepository.GetAllReviewsAsync();
            return Ok(reviews);
        }

        // GET: api/v1/Review/Product/{productId}
        [HttpGet("Product/{productId:guid}")]
        public async Task<IActionResult> GetReviewsByProductId(Guid productId)
        {
            var reviews = await _reviewRepository.GetReviewsByProductIdAsync(productId);
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
            var reviews = await _reviewRepository.GetReviewsByUserIdAsync(userId);
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
            var review = await _reviewRepository.GetAsync(r => r.Id == id);
            if (review == null)
            {
                return NotFound("Review not found.");
            }
            return Ok(review);
        }

        // POST: api/v1/Review
        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] Review review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdReview = await _reviewRepository.CreateAsync(review);
            return CreatedAtAction(nameof(GetReviewById), new { id = createdReview.Id }, createdReview);
        }

        // PUT: api/v1/Review/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateReview(Guid id, [FromBody] Review review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != review.Id)
            {
                return BadRequest("ID mismatch.");
            }
            var updateResult = await _reviewRepository.UpdateByIdAsync(review);
            if (!updateResult)
            {
                return NotFound("Review not found.");
            }
            return NoContent();
        }

        // DELETE: api/v1/Review/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteReview(Guid id)
        {
            var deleteResult = await _reviewRepository.DeleteByIdAsync(id);
            if (!deleteResult)
            {
                return NotFound("Review not found.");
            }
            return NoContent();
        }
    }
}
