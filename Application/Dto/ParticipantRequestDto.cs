namespace Application.Dto
{
    public class ParticipantRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Email { get; set; }
    }
}
