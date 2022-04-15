using Storage.Domain.UserData;

namespace Storage.Application.Repositories;

public interface IRoleRepository
{
    Role Default { get; }
    Role Editor { get; }
    Role Admin { get; }

    Task<List<Role>> GetRoles();
}
