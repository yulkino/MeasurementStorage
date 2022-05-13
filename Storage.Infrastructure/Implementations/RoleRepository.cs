using Microsoft.EntityFrameworkCore;
using Storage.Application.Repositories;
using Storage.Domain.UserData;
using Storage.Infrastructure.Data;

namespace Storage.Infrastructure.Implementations;

internal class RoleRepository : Repository, IRoleRepository
{
    private string _defaultRoleName = "Default";
    private string _editorRoleName = "Editor";
    private string _adminRoleName = "Admin";

    public RoleRepository(ApplicationDbContext context) : base(context) { }

    public Task<List<Role>> GetRolesAsync(CancellationToken cancellationToken) 
        => Context.Roles.ToListAsync(cancellationToken);

    public Task<Role> GetDefaultRoleAsync(CancellationToken cancellationToken)
        => Context.Roles.FindAsync(_defaultRoleName, cancellationToken).AsTask()!;

    public Task<Role> GetEditorRoleAsync(CancellationToken cancellationToken)
        => Context.Roles.FindAsync(_editorRoleName, cancellationToken).AsTask()!;

    public Task<Role> GetAdminRoleAsync(CancellationToken cancellationToken)
        => Context.Roles.FindAsync(_adminRoleName, cancellationToken).AsTask()!;
}
