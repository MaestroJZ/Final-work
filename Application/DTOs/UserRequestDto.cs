namespace Application.DTOs;

public class UserRequestDto : BaseDto
{
    public string Login { get; set; } = "";
    
    public string Password { get; set; } = "";

}