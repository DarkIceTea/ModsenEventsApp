using Application.Interfaces;
using Core.Entities;
using Domain.Interfaces;
using Mapster;
using MediatR;

namespace Application.Auth.RegisterParticipant
{
    public class RegisterParticipantCommandHandler : IRequestHandler<RegisterParticipantCommand, Tokens>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService;

        public RegisterParticipantCommandHandler(IUnitOfWork unitOfWork, IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _authService = authService;
        }

        public async Task<Tokens> Handle(RegisterParticipantCommand command, CancellationToken cancellationToken)
        {
            var paricipant = command.Adapt<Core.Entities.Participant>();
            paricipant.RegistrationDate = DateTime.Now;
            paricipant.Id = Guid.NewGuid();
            paricipant.Role = "user";

            var participant = await _unitOfWork.ParticipantRepository.AddParicipantAsync(paricipant, cancellationToken);
            var tokens = _authService.GenerateTokens(participant);
            _unitOfWork.ParticipantRepository.SetRefreshTokenAsync(participant.Id, tokens.RefreshToken, cancellationToken);
            _unitOfWork.Save();

            return tokens;
        }
    }
}
