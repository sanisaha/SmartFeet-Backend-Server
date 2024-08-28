using System.ComponentModel.DataAnnotations;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.UserService
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

        public byte[] Salt { get; set; }

        [Required]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        [Required]
        public Role Role { get; set; }

    }
    // public class User mainly stay in the domain layer, need to remove
    public class UserReadDto : BaseReadDto<User>
    {
        public string? UserName { get; set; }
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public Role Role { get; set; }

        public override void FromEntity(User entity)
        {
            base.FromEntity(entity);
            UserName = entity.UserName;
            Email = entity.Email;
            PhoneNumber = entity.PhoneNumber;
            Role = entity.Role;
        }
    }
    public class UserCreateDto : ICreateDto<User>
    {
        public string? UserName { get; set; }
        public string Email { get; set; } = null!;
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public Role Role { get; set; }

        public User CreateEntity()
        {
            return new User
            {
                UserName = UserName,
                Email = Email,
                Password = Password,
                PhoneNumber = PhoneNumber,
                Role = Role
            };
        }
    }

    public class UserUpdateDto : IUpdateDto<User>
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public Role Role { get; set; }

        public User UpdateEntity(User entity)
        {
            entity.UserName = UserName;
            entity.Email = Email;
            entity.PhoneNumber = PhoneNumber;
            entity.Role = Role;
            return entity;
        }
    }
}