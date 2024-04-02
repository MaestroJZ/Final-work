using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class Ballot : Entity
{
    [Required]
    public int VotingId { get; set; }

    [ForeignKey("VotingId")]
    public Voting Voting { get; set; }

    [Required]
    public string Option { get; set; }
}