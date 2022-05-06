using MediatR;
using Storage.Application.Repositories;
using Storage.Domain.UserData;

namespace Storage.Application.UserMediator.GetUser;

internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;

    public CreateUserCommandHandler(IUserRepository userRepository, IRoleRepository roleRepository)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }

    public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var (login, email, password) = request;

        var user = await _userRepository.GetUserByEmailAsync(email, cancellationToken);
        if (user is not null)
            throw new ArgumentException($"User with email {email} already exists.");

        user = await _userRepository.GetUsersByLoginAsync(login, cancellationToken);
        if (user is not null)
            throw new ArgumentException($"User with login {login} already exists.");

        var defaultRoles = new List<Role>() { await _roleRepository.GetDefaultRoleAsync(cancellationToken) };

        user = new User(email, login, password, null, defaultRoles);
        await _userRepository.CreateUserAsync(user, cancellationToken);
        await _userRepository.SaveUserChangesAsync(cancellationToken);

        return user;
    }
}
