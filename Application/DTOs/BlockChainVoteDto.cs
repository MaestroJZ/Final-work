namespace Application.DTOs;

public class BlockChainVoteDto
{
    public Guid VoterId { get; set; }
    public Guid CandidateId { get; set; }
    public Guid ElectionId { get; set; }
    public DateTime Timestamp { get; set; }
}