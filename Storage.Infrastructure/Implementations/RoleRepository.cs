using Microsoft.EntityFrameworkCore;
using Storage.Application.Repositories;
using Storage.Domain.UserData;
using Storage.Infrastructure.Data;

namespace Storage.Infrastructure.Implementations;

public class RoleRepository : IRoleRepository
{
    private readonly ApplicationDbContext _context;

    private string _defaultRoleName = "Default";
    private string _editorRoleName = "Editor";
    private string _adminRoleName = "Admin";

    public RoleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<List<Role>> GetRolesAsync(CancellationToken cancellationToken) 
        => _context.Roles.ToListAsync(cancellationToken);

    public Task<Role> GetDefaultRole(CancellationToken cancellationToken)
        => (_context.Roles.FindAsync(_defaultRoleName, cancellationToken).AsTask())!;

    public Task<Role> GetEditorRole(CancellationToken cancellationToken)
        => (_context.Roles.FindAsync(_editorRoleName, cancellationToken).AsTask())!;

    public Task<Role> GetAdminRole(CancellationToken cancellationToken)
        => (_context.Roles.FindAsync(_adminRoleName, cancellationToken).AsTask())!;

    public Task SaveRoleChangesAsync(CancellationToken cancellationToken)
        => _context.SaveChangesAsync(cancellationToken);
}
