namespace Application.DTOs;

public class TransactionDto : BaseDto
{
    public string Hash { get; set; }
    public Guid CandidateId { get; set; }
}