namespace Application.DTOs;

public class VoteDto : BaseDto
{
    public Guid VoterId { get; set; }
    public Guid CandidateId { get; set; }
    public Guid ElectionId { get; set; }
}