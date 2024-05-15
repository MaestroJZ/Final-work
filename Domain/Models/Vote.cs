namespace Domain.Models;

public class Vote : Entity
{
    public Guid VoterId { get; set; }
    public Voter Voter { get; set; }
    
    public Guid ElectionId { get; set; }
    public Election Election { get; set; }
}