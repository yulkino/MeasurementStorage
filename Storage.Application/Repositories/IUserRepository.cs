using Storage.Domain.UserData;

namespace Storage.Application.Repositories;

public interface IUserRepository : IRepository
{
    Task<User?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<User>> GetAllUsersAsync(CancellationToken cancellationToken);
    Task CreateUserAsync(User user, CancellationToken cancellationToken);
    Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
    Task DeleteUserAsync(User user, CancellationToken cancellationToken);
    Task<List<User>> GetUsersByEmailOrLoginPartAsync(string textPart, CancellationToken cancellationToken);
    Task<User?> GetUserByLoginAsync(string login, CancellationToken cancellationToken);
}
