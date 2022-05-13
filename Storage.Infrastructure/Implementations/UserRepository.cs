using Microsoft.EntityFrameworkCore;
using Storage.Application.Repositories;
using Storage.Domain.UserData;
using Storage.Infrastructure.Data;

namespace Storage.Infrastructure.Implementations;

internal class UserRepository : Repository, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context) { }

    public Task CreateUserAsync(User user, CancellationToken cancellationToken) 
        => Context.Users.AddAsync(user, cancellationToken).AsTask();

    public Task DeleteUserAsync(User user, CancellationToken cancellationToken) 
        => Task.FromResult(Context.Users.Remove(user));

    public Task<List<User>> GetAllUsersAsync(CancellationToken cancellationToken)
        => Context.Users.ToListAsync(cancellationToken);

    public Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
        => Context.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);

    public Task<User?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken)
        => Context.Users.FindAsync(id, cancellationToken).AsTask();

    public Task<List<User>> GetUsersByEmailPartAsync(string emailPart, CancellationToken cancellationToken)
        => Context.Users.Where(u => u.Email.Contains(emailPart)).ToListAsync(cancellationToken);

    public Task<User?> GetUsersByLoginAsync(string login, CancellationToken cancellationToken)
        => Context.Users.FindAsync(login, cancellationToken).AsTask();

    public Task<List<User>> GetUsersByLoginPartAsync(string loginPart, CancellationToken cancellationToken)
        => Context.Users.Where(u => u.Login.Contains(loginPart)).ToListAsync(cancellationToken);
}
