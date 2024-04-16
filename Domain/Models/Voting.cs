using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Voting : Entity
{
    [Required]
    public string Title { get; set; }

    [Required]
    public bool IsActive { get; set; }

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }
    public ICollection<Ballot> Ballots { get; set; }
}