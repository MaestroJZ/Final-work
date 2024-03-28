namespace Application.DTOs;

public class VoterDto : BaseDto
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string PhoneNumber { get; set; }
}