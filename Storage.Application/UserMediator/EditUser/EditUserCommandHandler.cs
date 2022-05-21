using Storage.Application.Repositories;
using Storage.Application.Results;
using Storage.Domain.UserData;

namespace Storage.Application.UserMediator.EditUser;

internal sealed class EditUserCommandHandler : IOperationHandler<EditUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public EditUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var (userId, newLogin, newPassword, newAvatarUrl) = request;

        var user = await _userRepository.GetUserByIdAsync(userId, cancellationToken);
        if (user is null)
            return new DoesNotExist($"User with id {userId} not found");

        user.Login = newLogin ?? user.Login;
        user.AvatarUrl = newAvatarUrl ?? user.AvatarUrl;

        if (newPassword is not null)
            user.PasswordHash = _passwordHasher.Hash(newPassword);

        await _userRepository.SaveChangesAsync(cancellationToken);

        return new Success<User>(user);
    }
}
