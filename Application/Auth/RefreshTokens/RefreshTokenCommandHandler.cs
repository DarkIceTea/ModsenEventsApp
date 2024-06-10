using Application.Interfaces;
using Domain.Interfaces;
using MediatR;
using System.Security.Claims;

namespace Application.Auth.RefreshTokens
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokensCommand, Tokens>
    {
        private readonly IParticipantRepository _participantRepository;
        private readonly IAuthService _authService;
        public RefreshTokenCommandHandler(IAuthService authService, IParticipantRepository participantRepository)
        {
            _authService = authService;
            _participantRepository = participantRepository;
        }

        public async Task<Tokens> Handle(RefreshTokensCommand request, CancellationToken cancellationToken)
        {
            Guid id = _authService.GetParticipantId();
            var participant = await _participantRepository.GetParticipantByIdAsync(id, cancellationToken);
            if (!participant.RefreshToken.Equals(request.RefreshToken))
                throw new UnauthorizedAccessException("Refresh tokens don't match");

            var tokens = _authService.GenerateTokens(participant);
            _participantRepository.SetRefreshTokenAsync(id, tokens.RefreshToken, cancellationToken);
            return tokens;
        }
    }
}
