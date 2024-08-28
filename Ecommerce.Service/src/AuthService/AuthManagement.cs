using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.src.Auth;
using Ecommerce.Service.src.UserService;

namespace Ecommerce.Service.src.AuthService
{
    public class AuthManagement : IAuthManagement
    {
        private readonly ITokenService _tokenService;
        //private readonly IUserRepo _userRepo;
        private readonly IPasswordHasher _passwordHasher;

        public AuthManagement(ITokenService tokenService, IPasswordHasher passwordHasher)
        {
            _tokenService = tokenService;
            //_userService = userService;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> LoginAsync(UserCredentials userCredentials)
        {
            throw new NotImplementedException();
        }
    }
}