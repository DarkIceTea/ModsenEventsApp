using MediatR;

namespace Application.Auth.RefreshTokens
{
    public class RefreshTokensCommand : IRequest<Tokens>
    {
        public string RefreshToken { get; set; } 
    }
}
