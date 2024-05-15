using System.Numerics;

namespace Application.DTOs;

public class CandidateDto : BaseDto
{
    public string FullName { get; set; }
    public string Slogan { get; set; }
    public Guid ElectionId { get; set; }
}