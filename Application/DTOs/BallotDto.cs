namespace Application.DTOs;

public class BallotDto : BaseDto
{
    public int VotingId { get; set; }
    public string Option { get; set; }
}