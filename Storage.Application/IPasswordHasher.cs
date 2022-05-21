namespace Storage.Application;

public interface IPasswordHasher
{
    string Hash(string password);
    bool Compare(string password, string passwordHash);
}
