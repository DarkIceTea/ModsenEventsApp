using Application.Dto;
using FluentValidation;

namespace Application.Validators
{
    public class ParticipantRequestDtoValidator : AbstractValidator<ParticipantRequestDto>
    {
        public ParticipantRequestDtoValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();
            RuleFor(p => p.DateOfBirth).LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow).AddYears(-10));
            RuleFor(p => p.Email).NotEmpty().EmailAddress();
        }
    }
}
