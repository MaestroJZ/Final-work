namespace Domain.Models;

public class BlockchainVote
{
    public Guid VoterId { get; set; }
    public Guid CandidateId { get; set; }
    public Guid ElectionId { get; set; }
    public DateTime Timestamp { get; set; }
}