using FluentValidation;

namespace Application.Event.Commands.CreateEvent
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        public CreateEventCommandValidator() { }
    }
}
