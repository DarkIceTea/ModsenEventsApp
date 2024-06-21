namespace Core.Entities
{
    public class Participant
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public List<Event> Events { get; set; } = new List<Event>();
        public string? RefreshToken { get; set; }
    }
}
