
using Ecommerce.Domain.src.Entities.ReviewAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.ReviewService
{
    public interface IReviewManagement : IBaseService<Review, ReviewReadDto, ReviewCreateDto, ReviewUpdateDto>
    {
        Task<Review> CreateAsync(ReviewCreateDto createDto);
        Task<ReviewUpdateDto> UpdateAsync(Guid id, ReviewUpdateDto updateDto);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<ReviewReadDto>> GetReviewsByProductIdAsync(Guid productId);
        Task<IEnumerable<ReviewReadDto>> GetReviewsByUserIdAsync(Guid userId);
        Task<IEnumerable<ReviewReadDto>> GetAllReviewsAsync();
        Task<ReviewReadDto> GetReviewByIdAsync(Guid reviewId);
    }
}