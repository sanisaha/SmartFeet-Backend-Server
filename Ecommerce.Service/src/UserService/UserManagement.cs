using Ecommerce.Domain.src.Auth;
using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Domain.src.UserAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.UserService
{
    public class UserManagement : BaseService<User, UserReadDto, UserCreateDto, UserUpdateDto>, IUserManagement
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UserManagement(IUserRepository userRepository, IPasswordHasher passwordHasher) : base(userRepository)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }
        public override async Task<UserReadDto> CreateAsync(UserCreateDto createDto)
        {
            _passwordHasher.HashPassword(createDto.Password, out string hashedPassword, out byte[] salt);
            var user = createDto.CreateEntity();
            user.Password = hashedPassword;
            user.Salt = salt;
            await _userRepository
            .CreateAsync(user);
            var userRead = new UserReadDto();
            userRead.FromEntity(user);
            return userRead;
        }

        public async Task<UserReadDto> GetByCredentialsAsync(UserCredentials userCredentials)
        {
            var user = await _userRepository.GetUserByCredentialAsync(userCredentials);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            var userRead = new UserReadDto();
            userRead.FromEntity(user);
            return userRead;
        }

        public async Task<bool> UpdatePasswordAsync(Guid userId, string newPassword)
        {
            return await _userRepository.UpdatePasswordAsync(userId, newPassword);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _userRepository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<UserReadDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllUsers();
            var userReads = users.Select(user =>
            {
                var userRead = new UserReadDto();
                userRead.FromEntity(user);
                return userRead;
            });
            return userReads;
        }

        public async Task<UserReadDto> GetByIdAsync(Guid id)
        {
            var user = await _userRepository.GetAsync(u => u.Id == id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            var userRead = new UserReadDto();
            userRead.FromEntity(user);
            return userRead;
        }

        public async Task<UserReadDto> UpdateAsync(Guid id, UserUpdateDto updateDto)
        {
            var user = await _userRepository.GetAsync(u => u.Id == id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            updateDto.UpdateEntity(user);
            await _userRepository.UpdateByIdAsync(user);
            var userRead = new UserReadDto();
            userRead.FromEntity(user);
            return userRead;
        }

        public async Task<UserReadDto> GetByEmailAsync(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            var userRead = new UserReadDto();
            userRead.FromEntity(user);
            return userRead;
        }
    }
}