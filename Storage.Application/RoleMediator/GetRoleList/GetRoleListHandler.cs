using MediatR;
using Storage.Application.Repositories;
using Storage.Domain.UserData;

namespace Storage.Application.RoleMediator.GetRoleList;

internal sealed class GetRoleListHandler : IRequestHandler<GetRoleListQuery, List<Role>>
{
    private readonly IRoleRepository _roleRepository;

    public GetRoleListHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public Task<List<Role>> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
        => _roleRepository.GetRolesAsync(cancellationToken);
}
