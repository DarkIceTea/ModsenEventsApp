using Application.Interfaces;
using Core.Entities;
using Domain.Interfaces;
using Mapster;
using MediatR;

namespace Application.Auth.RegisterParticipant
{
    public class RegisterParticipantCommandHandler : IRequestHandler<RegisterParticipantCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterParticipantCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(RegisterParticipantCommand command, CancellationToken cancellationToken)
        {
            var paricipant = command.Adapt<Core.Entities.Participant>();
            paricipant.RegistrationDate = DateTime.Now;
            paricipant.Id = Guid.NewGuid();
            paricipant.Role = "user";

            var res = await _unitOfWork.ParticipantRepository.AddParicipantAsync(paricipant, cancellationToken);
            _unitOfWork.Save();

            return res;
        }
    }
}
