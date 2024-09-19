using Ecommerce.Domain.src.Auth;
using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Domain.src.UserAggregate;
using Ecommerce.Service.src.AuthService;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.UserService
{
    public class UserManagement : BaseService<User, UserReadDto, UserCreateDto, UserUpdateDto>, IUserManagement
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;

        public UserManagement(IUserRepository userRepository, IPasswordHasher passwordHasher, ITokenService tokenService) : base(userRepository)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
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

        public async Task<bool> UpdatePasswordAsync(Guid userId, string newPassword)
        {
            return await _userRepository.UpdatePasswordAsync(userId, newPassword);
        }


        public async Task<UserReadDto?> GetUserByEmail(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                return null;
            }
            var userRead = new UserReadDto();
            userRead.FromEntity(user);
            return userRead;
        }

        public async Task<UserReadDto> GetUserProfileByToken(string token)
        {
            var tokenData = _tokenService.GetTokenData(token);
            var userId = Guid.Parse(tokenData.Id);
            var user = await _userRepository.GetAsync(userId);
            var userRead = new UserReadDto();
            userRead.FromEntity(user);
            return userRead;
        }

    }
}