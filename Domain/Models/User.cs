namespace Domain.Models;

public class User : Entity
{
    public string Login { get; set; }
    
    public string HashPassword { get; set; }

    public string Salt { get; set; }
}
