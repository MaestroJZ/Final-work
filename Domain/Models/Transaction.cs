namespace Domain.Models;

public class Transaction : Entity
{
    public string Hash { get; set; }
    public Guid CandidateId { get; set; }
    public Candidate Candidate { get; set; }
}