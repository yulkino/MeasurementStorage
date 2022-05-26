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
        => GetRoleASync(_defaultRoleName, cancellationToken);

    public Task<Role> GetEditorRoleAsync(CancellationToken cancellationToken)
        => GetRoleASync(_editorRoleName, cancellationToken);

    public Task<Role> GetAdminRoleAsync(CancellationToken cancellationToken)
        => GetRoleASync(_adminRoleName, cancellationToken);

    private Task<Role> GetRoleASync(string roleName, CancellationToken cancellationToken)
        => Context.Roles.FirstOrDefaultAsync(r => r.Name == roleName, cancellationToken)!;
}
