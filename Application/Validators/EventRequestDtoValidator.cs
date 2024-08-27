using Application.Dto;
using FluentValidation;

namespace Application.Validators
{
    public class EventRequestDtoValidator : AbstractValidator<EventRequestDto>
    {
        public EventRequestDtoValidator()
        {
            RuleFor(eventRequestDto => eventRequestDto.Name).NotEmpty().MaximumLength(250);
            RuleFor(eventRequestDto => eventRequestDto.MaxParticipants).GreaterThan(0);
            RuleFor(eventRequestDto => eventRequestDto.Location).NotEmpty().MaximumLength(250);
            RuleFor(eventRequestDto => eventRequestDto.Category).NotEmpty().MaximumLength(250);
            RuleFor(eventRequestDto => eventRequestDto.Description).NotEmpty().MaximumLength(250);
            RuleFor(eventRequestDto => eventRequestDto.Date).GreaterThan(DateTime.UtcNow);
        }
    }
}
