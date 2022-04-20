using Storage.Domain.UserData;

namespace Storage.Application.Repositories;

public interface IUserRepository
{
    Task<User?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<User>> GetAllUsersAsync(CancellationToken cancellationToken);
    Task CreateUserAsync(User user, CancellationToken cancellationToken);
    Task<User?> GetUserByEmail(string email, CancellationToken cancellationToken);
    void DeleteUser(User user);
    Task<List<User>> GetUsersByEmailPartAsync(string emailPart, CancellationToken cancellationToken);
    Task<List<User>> GetUsersByLoginPartAsync(string loginPart, CancellationToken cancellationToken);
    Task SaveUserChangesAsync(CancellationToken cancellationToken);
}
