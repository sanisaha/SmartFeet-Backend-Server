using Ecommerce.Domain.src.Auth;
using Ecommerce.Service.src.AuthService;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Http.HttpResults;



namespace Ecommerce.Infrastructure.src.Repository.Service
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<(string Uid, string Email)> GenerateIdAndEmailFromFirebaseToken(GoogleLoginRequest request)
        {

            if (FirebaseApp.DefaultInstance == null)
            {
                FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromJson(Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS"))
                });
            }
            // Verify the Firebase ID token
            FirebaseToken decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(request.IdToken);
            string uid = decodedToken.Uid;
            string email = decodedToken.Claims["email"].ToString();

            return (uid, email);
        }
        public string GenerateToken(Token token)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, token.Id.ToString()),
                new Claim(ClaimTypes.Role, token.Role.ToString()),
            };
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _configuration["Jwt:Issuer"],
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = signingCredentials
            };
            var tokenObj = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(tokenObj);

        }

        public TokenData GetTokenData(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            // Extract necessary claims, e.g., user ID from the token
            var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "nameid");

            if (userIdClaim == null)
            {
                throw new Exception("Invalid token data.");
            }

            return new TokenData
            {
                Id = userIdClaim.Value,
                // Extract other claims if needed
            };
        }
    }
}
