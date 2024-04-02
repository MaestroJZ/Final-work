using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class Vote : Entity
{
    [Required]
    public int VotingId { get; set; }

    [ForeignKey("VotingId")]
    public Voting Voting { get; set; }

    [Required]
    public int BallotId { get; set; }

    [ForeignKey("BallotOptionId")]
    public Ballot Ballot { get; set; }

    [Required]
    public string FullName { get; set; }

    [Required]
    public string PhoneNumber { get; set; }

    [Required]
    public DateTime VoteDate { get; set; }
}