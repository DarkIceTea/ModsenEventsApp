using Application.Auth;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        public Tokens GenerateTokens(Core.Entities.Participant participant);
    }
}
