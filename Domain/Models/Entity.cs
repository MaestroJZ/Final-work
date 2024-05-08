using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Entity 
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = null;
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; } = DateTime.UtcNow;
}