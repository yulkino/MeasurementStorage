using Storage.Domain.UserData;

namespace Storage.Application.Repositories;

public interface IRoleRepository
{
    Task<List<Role>> GetRolesAsync(CancellationToken cancellationToken);
    Task<Role> GetDefaultRole(CancellationToken cancellationToken);
    Task<Role> GetEditorRole(CancellationToken cancellationToken);
    Task<Role> GetAdminRole(CancellationToken cancellationToken);
    Task SaveRoleChangesAsync(CancellationToken cancellationToken);
}
