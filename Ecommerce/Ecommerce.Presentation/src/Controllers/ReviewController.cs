using Ecommerce.Domain.src.Entities.ReviewAggregate;
using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Service.src.ProductService;
using Ecommerce.Service.src.ReviewService;
using Ecommerce.Service.src.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Presentation.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ReviewController : AppController<Review, ReviewReadDto, ReviewCreateDto, ReviewUpdateDto>
    {
        private readonly IReviewManagement _reviewManagement;
        private readonly IProductManagement _productManagement;
        private readonly IUserManagement _userManagement;

        public ReviewController(IReviewManagement reviewManagement, IProductManagement productManagement, IUserManagement userManagement) : base(reviewManagement)
        {
            _reviewManagement = reviewManagement;
            _productManagement = productManagement;
            _userManagement = userManagement;
        }

        [Authorize]
        public override async Task<ActionResult<ReviewReadDto>> CreateAsync(ReviewCreateDto entity)
        {
            var existingProduct = await _productManagement.GetByIdAsync(entity.ProductId);
            if (existingProduct == null)
            {
                return NotFound(new { message = "ProductId not found." });
            }
            var existingUser = await _userManagement.GetByIdAsync(entity.UserId);
            if (existingUser == null)
            {
                return NotFound(new { message = "UserId not found." });
            }
            return await base.CreateAsync(entity);

        }

        [Authorize]
        public override async Task<ActionResult<ReviewReadDto>> UpdateAsync(Guid id, ReviewUpdateDto entity)
        {
            return await base.UpdateAsync(id, entity);
        }

        [Authorize]
        public override async Task<ActionResult> DeleteAsync(Guid id)
        {
            return await base.DeleteAsync(id);
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
        [Authorize]
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
