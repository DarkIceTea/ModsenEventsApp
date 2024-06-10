using Application.Auth;
using Application.Interfaces;
using Core.Entities;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Cryptography;

namespace Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        IHttpContextAccessor _httpContextAccessor;
        HttpContext _httpContext;

        public AuthService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpContext = httpContextAccessor.HttpContext;
        }
        public Tokens GenerateTokens(Participant participant)
        {
            return new Tokens() { AccessToken = GenerateAccessToken(participant),
                                    RefreshToken = GenerateRefreshToken()};
        }

        public string GenerateAccessToken(Participant participant)
        {
            var claims = new[]
            {   
                new Claim(ClaimTypes.NameIdentifier, participant.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, participant.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, participant.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("keykeykeykeykeykeykeykeykeykeykeykeykeykey"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
            issuer: "EventWebApi",
            audience: "EventWebApi",
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(10),
            signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public Guid GetParticipantId()
        {
            string? ParticipantId = _httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (ParticipantId is null)
                throw new InvalidOperationException("User Id not found");
            return Guid.Parse(ParticipantId);
        }
    }
}
