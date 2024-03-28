namespace Domain.Models;

public class Voter : Entity
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string PhoneNumber { get; set; }
}