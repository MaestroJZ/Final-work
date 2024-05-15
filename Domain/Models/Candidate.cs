using System.Numerics;

namespace Domain.Models;

public class Candidate : Entity
{
    public string FullName { get; set; }
    public string Slogan { get; set; }
    public Guid ElectionId { get; set; }
    public Election Election { get; set; }
    
    public ICollection<Transaction> Transactions { get; set; }
}