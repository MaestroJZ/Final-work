namespace Application.Services;

public interface IHashPasswordService
{
    (string Hash, string Salt) HashPassword(string password);
}
