using Storage.Domain.UserData;

namespace Storage.Application.Repositories;

public interface IRoleRepository
{
    Task<List<Role>> GetRolesAsync(CancellationToken cancellationToken);
    Task<Role> GetDefaultRoleAsync(CancellationToken cancellationToken);
    Task<Role> GetEditorRoleAsync(CancellationToken cancellationToken);
    Task<Role> GetAdminRoleAsync(CancellationToken cancellationToken);
    Task SaveRoleChangesAsync(CancellationToken cancellationToken);
}
