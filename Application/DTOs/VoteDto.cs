namespace Application.DTOs;

public class VoteDto : BaseDto
{
    public int VotingId { get; set; }
    public int BallotOptionId { get; set; }
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime VoteDate { get; set; }
}