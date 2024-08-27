using System.ComponentModel.DataAnnotations;
using Ecommerce.Domain.src.Shared;

namespace Ecommerce.Domain.src.UserAggregate
{
    public enum Role
    {
        Admin,
        User
    }
    public class User : BaseEntity
    {
        [Required]
        [StringLength(100, ErrorMessage = "User name must be at least {2} characters long.", MinimumLength = 2)]
        public string? UserName { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;


        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "Must be between 5 and 100 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        public required byte[] Salt { get; set; }

        [Required]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        [Required]
        public Role Role { get; set; }

    }
}