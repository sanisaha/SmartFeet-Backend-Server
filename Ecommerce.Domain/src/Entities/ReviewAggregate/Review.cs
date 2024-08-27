using Ecommerce.Domain.src.ProductAggregate;
using Ecommerce.Domain.src.Shared;
using Ecommerce.Domain.src.UserAggregate;

namespace Ecommerce.Domain.src.Entities.ReviewAggregate
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
}