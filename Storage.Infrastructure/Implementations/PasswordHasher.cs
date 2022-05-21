using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Storage.Application;
using System.Security.Cryptography;

namespace Storage.Infrastructure.Implementations;

internal class PasswordHasher : IPasswordHasher
{
    private const int SaltLength = 16;
    private const int HashLength = 32;
    private const int IterationsCount = 100_000;
    private const KeyDerivationPrf Prf = KeyDerivationPrf.HMACSHA256;

    public string Hash(string password)
    {
        var salt = CreateRandomSalt();
        return ComputeHashWithSalt(password, salt);
    }

    public bool Compare(string password, string passwordHash)
    {
        var salt = GetSaltFromHash(passwordHash);
        var hash = ComputeHashWithSalt(password, salt);
        return hash == passwordHash;
    }

    private static string ComputeHashWithSalt(string password, byte[] salt)
        => Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: Prf,
            iterationCount: IterationsCount,
            numBytesRequested: HashLength));

    private static byte[] CreateRandomSalt()
    {
        var salt = new byte[SaltLength];
        RandomNumberGenerator.Create().GetBytes(salt);
        return salt;
    }

    private static byte[] GetSaltFromHash(string hash)
    {
        var salt = new byte[SaltLength];
        var hashBytes = Convert.FromBase64String(hash);
        Array.Copy(hashBytes, 0, salt, 0, SaltLength);
        return salt;
    }
}
