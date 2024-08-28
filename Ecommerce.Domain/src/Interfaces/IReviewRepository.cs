using Ecommerce.Domain.src.Entities.ReviewAggregate;

namespace Ecommerce.Domain.src.Interfaces
{
    public interface IReviewRepository
    {
        Task<bool> CreateReviewAsync(Review review);
        Task<bool> UpdateReviewAsync(Review review);
        Task<bool> DeleteReviewAsync(Guid reviewId);
        Task<Review> GetReviewByIdAsync(Guid reviewId);
        Task<IEnumerable<Review>> GetReviewsByProductIdAsync(Guid productId);
        Task<IEnumerable<Review>> GetReviewsByUserIdAsync(Guid userId);
        Task<IEnumerable<Review>> GetAllReviewsAsync();
    }
}