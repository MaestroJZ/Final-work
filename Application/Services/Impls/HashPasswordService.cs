namespace Application.Services.Impls;

public class HashPasswordService : IHashPasswordService
{
    /// <inheritdoc/>
    public (string Hash, string Salt) HashPassword(string password)
    {
        var salt = BCrypt.Net.BCrypt.GenerateSalt();
        var hash = BCrypt.Net.BCrypt.HashPassword(password, salt);
        return (hash, salt);
    }
}
