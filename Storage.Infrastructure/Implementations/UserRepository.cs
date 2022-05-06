﻿using Microsoft.EntityFrameworkCore;
using Storage.Application.Repositories;
using Storage.Domain.UserData;
using Storage.Infrastructure.Data;

namespace Storage.Infrastructure.Implementations;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task CreateUserAsync(User user, CancellationToken cancellationToken) 
        => _context.Users.AddAsync(user, cancellationToken).AsTask();

    public Task DeleteUserAsync(User user) 
        => Task.FromResult(_context.Users.Remove(user));

    public Task<List<User>> GetAllUsersAsync(CancellationToken cancellationToken)
        => _context.Users.ToListAsync(cancellationToken);

    public Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
        => _context.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);

    public Task<User?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken)
        => _context.Users.FindAsync(id, cancellationToken).AsTask();

    public Task<List<User>> GetUsersByEmailPartAsync(string emailPart, CancellationToken cancellationToken)
        => _context.Users.Where(u => u.Email.Contains(emailPart)).ToListAsync(cancellationToken);

    public Task<User?> GetUsersByLoginAsync(string login, CancellationToken cancellationToken)
        => _context.Users.FindAsync(login, cancellationToken).AsTask();

    public Task<List<User>> GetUsersByLoginPartAsync(string loginPart, CancellationToken cancellationToken)
        => _context.Users.Where(u => u.Login.Contains(loginPart)).ToListAsync(cancellationToken);

    public Task SaveUserChangesAsync(CancellationToken cancellationToken) 
        => _context.SaveChangesAsync(cancellationToken);
}
