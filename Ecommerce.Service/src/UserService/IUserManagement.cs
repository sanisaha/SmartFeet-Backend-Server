using Ecommerce.Domain.src.Auth;
using Ecommerce.Domain.src.UserAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.UserService
{
    public interface IUserManagement : IBaseService<User, UserReadDto, UserCreateDto, UserUpdateDto>
    {
        Task<UserReadDto> GetByCredentialsAsync(UserCredentials userCredentials);
        Task<bool> UpdatePasswordAsync(int userId, string newPassword);
    }
}