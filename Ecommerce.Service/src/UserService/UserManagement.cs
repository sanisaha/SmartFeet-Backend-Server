namespace Ecommerce.Service.src.UserService
{
    public class UserManagement : IUserManagement
    {
        public async Task<UserReadDto> CreateAsync(UserCreateDto createDto)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserReadDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<UserReadDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserReadDto> UpdateAsync(Guid id, UserUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}