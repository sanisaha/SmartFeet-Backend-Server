using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.UserService
{
    public interface IUserManagement : IBaseService<User, UserReadDto, UserCreateDto, UserUpdateDto>
    {
        // need to implement GetByCredentialsAsync, UpdatePasswordAsync methods here
    }
}