using Application.Interfaces;
using Domain.Interfaces;
using MediatR;
using Application.Exceptions;
namespace Application.Auth.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Tokens>
    {
        private readonly IAuthService _authService;
        private readonly IUnitOfWork _unitOfWork;

        public LoginCommandHandler(IUnitOfWork unitOfWork, IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _authService = authService;
        }
        public async Task<Tokens> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var participant = await _unitOfWork.ParticipantRepository.GetByEmailAsync(command.Email, cancellationToken);

            if (participant?.FirstName != command.Name)
                throw new NotFoundException();

            var tokens = _authService.GenerateTokens(participant);
            _unitOfWork.ParticipantRepository.SetRefreshTokenAsync(participant.Id, tokens.RefreshToken, cancellationToken);
            _unitOfWork.Save();
            return tokens;
        }
    }
}
