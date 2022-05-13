using MediatR;
using Storage.Application.Repositories;
using Storage.Application.Results;
using Storage.Domain.UserData;

namespace Storage.Application.UserMediator.CreateUser;

internal sealed class CreateUserCommandHandler : IOperationHandler<CreateUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;

    public CreateUserCommandHandler(IUserRepository userRepository, IRoleRepository roleRepository)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }

    public async Task<OperationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var (login, email, password) = request;

        var user = await _userRepository.GetUserByEmailAsync(email, cancellationToken);
        if (user is not null)
            return new KeyIsOccupied($"User with email {email} already exist");

        user = await _userRepository.GetUsersByLoginAsync(login, cancellationToken);
        if (user is not null)
            return new KeyIsOccupied($"User with login {login} already exist");

        var defaultRoles = new List<Role> { await _roleRepository.GetDefaultRoleAsync(cancellationToken) };

        user = new User(email, login, password, null, defaultRoles);
        await _userRepository.CreateUserAsync(user, cancellationToken);
        await _userRepository.SaveChangesAsync(cancellationToken);

        return new Created<User>(user);
    }
}
