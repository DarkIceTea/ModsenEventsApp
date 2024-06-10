using Core.Entities;
using Domain.Interfaces;
using Mapster;
using MediatR;

namespace Application.Participant.Commands.RegisterParticipant
{
    public class RegisterParticipantCommandHandler : IRequestHandler<RegisterParticipantCommand, Guid>
    {
        private readonly IParticipantRepository _participantRepository;

        public RegisterParticipantCommandHandler(IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        public async Task<Guid> Handle(RegisterParticipantCommand command, CancellationToken cancellationToken)
        {
            var paricipant = command.Adapt<Core.Entities.Participant>();
            paricipant.RegistrationDate = DateTime.Now;
            paricipant.Id = Guid.NewGuid();
            paricipant.Role = "user";

            return await _participantRepository.AddParicipantAsync(paricipant, cancellationToken);
        }
    }
}
