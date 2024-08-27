namespace Application.Dto
{
    public class EventResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public int MaxParticipants { get; set; }
        public List<Guid> Participants { get; set; }
        public byte[]? Image { get; set; }
    }
}
