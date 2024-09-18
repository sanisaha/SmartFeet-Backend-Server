using Ecommerce.Domain.src.Auth;

namespace Ecommerce.Service.src.AuthService
{
    public interface ITokenService
    {
        string GenerateToken(Token token);
        //public async Task<UserReadDto> GetUserProfileByToken(string token)
        TokenData GetTokenData(string token);
    }
}