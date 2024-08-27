using Ecommerce.Domain.src.Entities.ReviewAggregate;

namespace Ecommerce.Domain.src.Interfaces
{
    public interface IReviewRepository
    {
        public bool CreateReviewAsync(Review review);
        public bool UpdateReviewAsync(Review review);
        public bool DeleteReviewAsync(Guid reviewId);
        public Review GetReviewByIdAsync(Guid reviewId);
        Task<IEnumerable<Review>> GetReviewsByProductIdAsync(Guid productId);
        public IEnumerable<Review> GetReviewsByUserIdAsync(Guid userId);
        public IEnumerable<Review> GetAllReviewsAsync();
    }
}