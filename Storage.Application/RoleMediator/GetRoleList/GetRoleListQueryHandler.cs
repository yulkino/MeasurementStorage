using Storage.Application.Repositories;
using Storage.Application.Results;
using Storage.Domain.UserData;

namespace Storage.Application.RoleMediator.GetRoleList;

internal sealed class GetRoleListQueryHandler : IOperationHandler<GetRoleListQuery>
{
    private readonly IRoleRepository _roleRepository;

    public GetRoleListQueryHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<OperationResult> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
        => new Success<List<Role>>(await _roleRepository.GetRolesAsync(cancellationToken));
}
