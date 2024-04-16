namespace Application.DTOs;

public class VotingDto : BaseDto
{
    public string Title { get; set; }
    public bool IsActive { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public ICollection<BallotDto> Ballots { get; set; }
}