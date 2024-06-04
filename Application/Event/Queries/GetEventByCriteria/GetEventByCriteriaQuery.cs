using MediatR;

namespace Application.Event.Queries.GetEventByCriteria
{
    public class GetEventByCriteriaQuery : IRequest<IEnumerable<Core.Entities.Event>>
    {
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
    }
}
