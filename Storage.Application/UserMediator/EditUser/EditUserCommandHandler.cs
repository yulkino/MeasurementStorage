using MediatR;
using Storage.Application.Repositories;
using Storage.Domain.UserData;

namespace Storage.Application.UserMediator.EditUser;

internal sealed class EditUserCommandHandler : IRequestHandler<EditUserCommand, User>
{
    private readonly IUserRepository _userRepository;

    public EditUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var (userId, newLogin, newPassword) = request;

        var user = await _userRepository.GetUserByIdAsync(userId, cancellationToken);
        if (user is null)
            throw new ArgumentException($"User with id {userId} not found");

        user.Login = newLogin;
        user.Password = newPassword;
        await _userRepository.SaveUserChangesAsync(cancellationToken);

        return user;
    }
}
