
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.ReviewService
{
    public class ReviewManagement : BaseService<Review, ReviewReadDto, ReviewCreateDto, ReviewUpdateDto>, IReviewManagement
    {
        public async Task<ReviewCreateDto> CreateAsync(ReviewCreateDto createDto)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ReviewReadDto>> GetAllReviewsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ReviewReadDto> GetReviewByIdAsync(Guid reviewId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ReviewReadDto>> GetReviewsByProductIdAsync(Guid productId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ReviewReadDto>> GetReviewsByUserIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<ReviewUpdateDto> UpdateAsync(Guid id, ReviewUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}