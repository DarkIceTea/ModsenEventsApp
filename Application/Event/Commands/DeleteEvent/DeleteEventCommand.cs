using MediatR;
namespace Application.Event.Commands.DeleteEvent
{
    public class DeleteEventCommand : IRequest<DeleteEventCommand>
    {
        public Guid Id { get; set; }
    }
}
