using Ecommerce.Domain.src.Entities.ReviewAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.ReviewService
{
    public class ReviewReadDto : BaseReadDto<Review>
    {
        public DateTime ReviewDate { get; set; }
        public int Rating { get; set; }
        public string? ReviewText { get; set; }
        public string ReviewerName { get; set; }

        public override void FromEntity(Review entity)
        {
            base.FromEntity(entity);
            ReviewDate = entity.ReviewDate;
            Rating = entity.Rating;
            ReviewText = entity.ReviewText;
            ReviewerName = entity.ReviewerName;
        }
    }
    public class ReviewCreateDto : ICreateDto<Review>
    {
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public DateTime ReviewDate { get; set; }
        public int Rating { get; set; }
        public string? ReviewText { get; set; }
        public string ReviewerName { get; set; }
        public Review CreateEntity()
        {
            return new Review
            {
                ProductId = ProductId,
                UserId = UserId,
                ReviewDate = ReviewDate,
                Rating = Rating,
                ReviewText = ReviewText,
                ReviewerName = ReviewerName
            };
        }
    }
    public class ReviewUpdateDto : IUpdateDto<Review>
    {
        public Guid Id { get; set; }
        public DateTime ReviewDate { get; set; }
        public int Rating { get; set; }
        public string? ReviewText { get; set; }
        public string ReviewerName { get; set; }
        public Review UpdateEntity(Review entity)
        {
            entity.ReviewDate = ReviewDate;
            entity.Rating = Rating;
            entity.ReviewText = ReviewText;
            entity.ReviewerName = ReviewerName;
            return entity;
        }
    }
}