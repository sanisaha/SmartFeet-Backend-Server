
using Ecommerce.Domain.src.Entities.ReviewAggregate;
using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.ReviewService
{
    public class ReviewManagement : BaseService<Review, ReviewReadDto, ReviewCreateDto, ReviewUpdateDto>, IReviewManagement
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewManagement(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public async Task<Review> CreateAsync(ReviewCreateDto createDto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(createDto.ReviewText))
                    throw new ArgumentException("Review text is required.");

                var reviewEntity = createDto.CreateEntity();
                return await _reviewRepository.CreateAsync(reviewEntity);

            }
            catch (Exception)
            {
                throw new Exception("Error creating review!.");
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var review = await _reviewRepository.GetAsync(r => r.Id == id);
                if (review == null)
                    throw new ArgumentException("Review not found.");

                await _reviewRepository.DeleteByIdAsync(id);
            }
            catch (Exception)
            {
                throw new Exception("Error deleting review!.");
            }
        }

        public async Task<IEnumerable<ReviewReadDto>> GetAllReviewsAsync()
        {
            try
            {
                var reviews = await _reviewRepository.GetAllReviewsAsync();
                return reviews.Select(r =>
                {
                    var reviewDto = new ReviewReadDto();
                    reviewDto.FromEntity(r);
                    return reviewDto;
                });
            }
            catch (Exception)
            {
                throw new Exception("Error getting reviews!.");
            }
        }

        public async Task<ReviewReadDto> GetReviewByIdAsync(Guid reviewId)
        {
            try
            {
                var review = await _reviewRepository.GetAsync(r => r.Id == reviewId);
                if (review == null)
                    throw new ArgumentException("Review not found.");

                var reviewDto = new ReviewReadDto();
                reviewDto.FromEntity(review);

                return reviewDto;
            }
            catch (Exception)
            {
                throw new Exception("Error getting review!.");
            }
        }

        public async Task<IEnumerable<ReviewReadDto>> GetReviewsByProductIdAsync(Guid productId)
        {
            try
            {
                var reviews = await _reviewRepository.GetReviewsByProductIdAsync(productId);
                return reviews.Select(r =>
                {
                    var reviewDto = new ReviewReadDto();
                    reviewDto.FromEntity(r);
                    return reviewDto;
                });
            }
            catch (Exception)
            {
                throw new Exception("Error getting reviews!.");
            }
        }

        public async Task<IEnumerable<ReviewReadDto>> GetReviewsByUserIdAsync(Guid userId)
        {
            try
            {
                var reviews = await _reviewRepository.GetReviewsByUserIdAsync(userId);
                return reviews.Select(r =>
                {
                    var reviewDto = new ReviewReadDto();
                    reviewDto.FromEntity(r);
                    return reviewDto;
                });
            }
            catch (Exception)
            {
                throw new Exception("Error getting reviews!.");
            }
        }

        public async Task<ReviewUpdateDto> UpdateAsync(Guid id, ReviewUpdateDto updateDto)
        {
            try
            {
                var existingReview = await _reviewRepository.GetAsync(r => r.Id == id);
                if (existingReview == null)
                    throw new ArgumentException("Review not found.");

                if (string.IsNullOrWhiteSpace(updateDto.ReviewText))
                    throw new ArgumentException("Review text is required.");

                var updatedReview = updateDto.UpdateEntity(existingReview);

                await _reviewRepository.UpdateByIdAsync(updatedReview);

                return updateDto;
            }
            catch (Exception)
            {
                throw new Exception("Error updating review!.");
            }
        }
    }
}