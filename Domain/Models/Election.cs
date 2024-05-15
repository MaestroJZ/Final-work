namespace Domain.Models;

public class Election : Entity
{
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Description { get; set; }
    
    public ICollection<Candidate> Candidates { get; set; }
}