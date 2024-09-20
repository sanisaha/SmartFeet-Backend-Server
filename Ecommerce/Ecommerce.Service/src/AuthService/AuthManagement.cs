using Ecommerce.Domain.Enums;
using Ecommerce.Domain.src.Auth;
using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Domain.src.UserAggregate;
using Ecommerce.Service.src.UserService;

namespace Ecommerce.Service.src.AuthService
{
    public class AuthManagement : IAuthManagement
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        //private readonly IUserRepo _userRepo;
        private readonly IPasswordHasher _passwordHasher;

        public AuthManagement(IUserRepository userRepository, ITokenService tokenService, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _passwordHasher = passwordHasher;
        }

        private string GenerateRandomPassword(int length = 16)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public async Task<string> LoginAsync(UserCredentials userCredentials)
        {
            var foundUserByEmail = await _userRepository.GetUserByEmail(userCredentials.Email);
            if (foundUserByEmail == null)
            {
                throw new Exception("User not found");
            }
            var isVerified = _passwordHasher.VerifyPassword(userCredentials.Password, foundUserByEmail.Password, foundUserByEmail.Salt);
            if (isVerified)
            {
                var token = new Token
                {
                    Id = foundUserByEmail.Id,
                    Email = foundUserByEmail.Email,
                    Role = foundUserByEmail.Role
                };
                return _tokenService.GenerateToken(token);
            }
            else
            {
                throw new Exception("Invalid password");
            }
        }

        public async Task<string> GoogleLoginAsync(GoogleLoginRequest request)
        {
            var (uid, email) = await _tokenService.GenerateIdAndEmailFromFirebaseToken(request);
            var foundUserByEmail = await _userRepository.GetUserByEmail(email);
            if (foundUserByEmail == null)
            {
                var user = new User
                {
                    Email = email,
                    Role = UserRole.User,
                    UserName = email,
                    Password = GenerateRandomPassword(),  // Generate a placeholder password
                    Salt = new byte[16],
                    PhoneNumber = "random",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow

                };
                var createdUser = await _userRepository.CreateAsync(user);
                var token = new Token
                {
                    Id = createdUser.Id,
                    Email = createdUser.Email,
                    Role = createdUser.Role
                };
                return _tokenService.GenerateToken(token);
            }
            else
            {
                var token = new Token
                {
                    Id = foundUserByEmail.Id,
                    Email = foundUserByEmail.Email,
                    Role = foundUserByEmail.Role
                };
                return _tokenService.GenerateToken(token);
            }
        }

        public async Task LogoutAsync()
        {
            throw new NotImplementedException();
        }
    }
}