
using Ecommerce.Domain.src.ProductAggregate;
using Ecommerce.Domain.src.Shared;
using Ecommerce.Domain.src.UserAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.ReviewService
{
    public class Review : BaseEntity
    {
        public DateTime ReviewDate { get; set; }
        public int Rating { get; set; }
        public string? ReviewText { get; set; }

        // Navigation properties
        public virtual User? User { get; set; }
        public virtual Product? Product { get; set; }

    }
    // Review entity remain the same as Review entity in Ecommerce.Domain, need to remove this class later
    public class ReviewReadDto : BaseReadDto<Review>
    {
        public DateTime ReviewDate { get; set; }
        public int Rating { get; set; }
        public string? ReviewText { get; set; }

        public override void FromEntity(Review entity)
        {
            base.FromEntity(entity);
            ReviewDate = entity.ReviewDate;
            Rating = entity.Rating;
            ReviewText = entity.ReviewText;
        }
    }
    public class ReviewCreateDto : ICreateDto<Review>
    {
        public DateTime ReviewDate { get; set; }
        public int Rating { get; set; }
        public string? ReviewText { get; set; }
        public Review CreateEntity()
        {
            return new Review
            {
                ReviewDate = ReviewDate,
                Rating = Rating,
                ReviewText = ReviewText
            };
        }
    }
    public class ReviewUpdateDto : IUpdateDto<Review>
    {
        public Guid Id { get; set; }
        public DateTime ReviewDate { get; set; }
        public int Rating { get; set; }
        public string? ReviewText { get; set; }
        public Review UpdateEntity(Review entity)
        {
            entity.ReviewDate = ReviewDate;
            entity.Rating = Rating;
            entity.ReviewText = ReviewText;
            return entity;
        }
    }
}