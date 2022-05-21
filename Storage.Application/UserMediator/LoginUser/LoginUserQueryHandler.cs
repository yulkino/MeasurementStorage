using Storage.Application.Repositories;
using Storage.Application.Results;
using Storage.Domain.UserData;

namespace Storage.Application.UserMediator.LoginUser;

internal sealed class LoginUserQueryHandler : IOperationHandler<LoginUserQuery>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public LoginUserQueryHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<OperationResult> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        var (login, password) = request;
        var user = await _userRepository.GetUserByLoginAsync(login, cancellationToken);
        if (user is null)
            return new DoesNotExist($"User with login {login} not found");
        if (!_passwordHasher.Compare(password, user.PasswordHash))
            return new PasswordDoesNotExist("Wrong password");

        return new Success<User>(user);
    }
}
