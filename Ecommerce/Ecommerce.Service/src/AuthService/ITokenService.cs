using Ecommerce.Domain.src.Auth;

namespace Ecommerce.Service.src.AuthService
{
    public interface ITokenService
    {
        string GenerateToken(Token token);
        TokenData GetTokenData(string token);
        //GenerateIdAndEmailFromFirebaseToken
        Task<(string Uid, string Email)> GenerateIdAndEmailFromFirebaseToken(GoogleLoginRequest request);

    }
}