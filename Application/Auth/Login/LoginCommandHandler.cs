﻿using Application.Interfaces;
using Domain.Interfaces;
using MediatR;
using Application.Exceptions;
namespace Application.Auth.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Tokens>
    {
        private readonly IAuthService _authService;
        private readonly IParticipantRepository _participantRepository;

        public LoginCommandHandler(IParticipantRepository participantRepository, IAuthService authService)
        {
            _participantRepository = participantRepository;
            _authService = authService;
        }
        public async Task<Tokens> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var participant = await _participantRepository.GetParticipantByEmailAsync(command.Email, cancellationToken);

            if (participant?.FirstName == command.Name)
                return _authService.GenerateTokens(participant);

            throw new NotFoundException();
        }
    }
}