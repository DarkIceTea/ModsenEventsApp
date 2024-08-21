using Application.Interfaces;
using Domain.Interfaces;
using MediatR;

namespace Application.Auth.RefreshTokens
{
    public class RefreshTokensCommandHandler : IRequestHandler<RefreshTokensCommand, Tokens>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService;
        public RefreshTokensCommandHandler(IAuthService authService, IUnitOfWork unitOfWork)
        {
            _authService = authService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Tokens> Handle(RefreshTokensCommand request, CancellationToken cancellationToken)
        {
            Guid id = _authService.GetParticipantId();
            var participant = await _unitOfWork.ParticipantRepository.GetByIdAsync(id, cancellationToken);
            if (!participant.RefreshToken.Equals(request.RefreshToken))
                throw new UnauthorizedAccessException("Refresh tokens don't match");

            var tokens = _authService.GenerateTokens(participant);
            _unitOfWork.ParticipantRepository.SetRefreshTokenAsync(id, tokens.RefreshToken, cancellationToken);
            _unitOfWork.Save();
            return tokens;
        }
    }
}
