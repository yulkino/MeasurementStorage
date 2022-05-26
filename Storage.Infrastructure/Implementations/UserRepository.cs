using Microsoft.EntityFrameworkCore;
using Storage.Application.Repositories;
using Storage.Domain.UserData;
using Storage.Infrastructure.Data;

namespace Storage.Infrastructure.Implementations;

internal class UserRepository : Repository, IUserRepository
{
    private readonly IQueryable<User> _usersWithRoles;

    public UserRepository(ApplicationDbContext context) : base(context)
    {
        _usersWithRoles = Context.Users
            .Include(u => u.Roles);
    }

    public Task CreateUserAsync(User user, CancellationToken cancellationToken)
        => Context.Users.AddAsync(user, cancellationToken).AsTask();

    public Task DeleteUserAsync(User user, CancellationToken cancellationToken)
        => Task.FromResult(Context.Users.Remove(user));

    public Task<List<User>> GetUsersByEmailOrLoginPartAsync(string textPart, CancellationToken cancellationToken)
        => Context.Users.Where(u =>
                EF.Functions.Like(u.Login, $"%{textPart}%")
                || EF.Functions.Like(u.Email, $"%{textPart}%"))
            .ToListAsync(cancellationToken);

    public Task<List<User>> GetAllUsersAsync(CancellationToken cancellationToken)
        => Context.Users.ToListAsync(cancellationToken);

    public Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
        => _usersWithRoles.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);

    public Task<User?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken)
        => _usersWithRoles.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

    public Task<User?> GetUserByLoginAsync(string login, CancellationToken cancellationToken)
        => _usersWithRoles.FirstOrDefaultAsync(u => u.Login == login, cancellationToken);
}
