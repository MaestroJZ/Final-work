namespace Application.Services;

public interface IJwtService 
{
    string GenerateToken(string voter);
}
