using Storage.Application.Repositories;
using Storage.Application.Results;
using Storage.Domain.UserData;
using static Storage.Application.UserMediator.EditUserRole.NewRole;

namespace Storage.Application.UserMediator.EditUserRole;

internal sealed class EditUserRoleCommandHandler : IOperationHandler<EditUserRoleCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;

    public EditUserRoleCommandHandler(IUserRepository userRepository, IRoleRepository roleRepository)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }

    public async Task<OperationResult> Handle(EditUserRoleCommand request, CancellationToken cancellationToken)
    {
        var (userId, newRoles) = request;

        var user = await _userRepository.GetUserByIdAsync(userId, cancellationToken);
        if (user is null)
            return new DoesNotExist($"User with id {userId} not found");

        var createdRoles = new List<Role>();

        foreach (var role in newRoles)
        {
            var newRole = role switch
            {
                Default => await _roleRepository.GetDefaultRoleAsync(cancellationToken),
                Editor => await _roleRepository.GetEditorRoleAsync(cancellationToken),
                Admin => await _roleRepository.GetAdminRoleAsync(cancellationToken),
                _ => throw new ArgumentOutOfRangeException()
            };

            if (createdRoles.Contains(newRole))
            {
                return new KeyIsOccupied("User should have unique roles");
            }

            createdRoles.Add(newRole);
        }

        user.Roles = createdRoles;

        await _userRepository.SaveChangesAsync(cancellationToken);

        return new Success<User>(user);
    }
}
