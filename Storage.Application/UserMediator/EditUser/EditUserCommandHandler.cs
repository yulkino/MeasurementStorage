using Storage.Application.Repositories;
using Storage.Application.Results;
using Storage.Domain.UserData;

namespace Storage.Application.UserMediator.EditUser;

internal sealed class EditUserCommandHandler : IOperationHandler<EditUserCommand>
{
    private readonly IUserRepository _userRepository;

    public EditUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var (userId, newLogin, newPassword, newAvatarUrl) = request;

        var user = await _userRepository.GetUserByIdAsync(userId, cancellationToken);
        if (user is null)
            return new DoesNotExist($"User with id {userId} not found");

        user.Login = newLogin;
        user.Password = newPassword;
        user.AvatarUrl = newAvatarUrl;
        await _userRepository.SaveChangesAsync(cancellationToken);

        return new Success<User>(user);
    }
}
