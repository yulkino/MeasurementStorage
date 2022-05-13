using Storage.Application.Repositories;
using Storage.Application.Results;
using Storage.Domain.UserData;

namespace Storage.Application.UserMediator.GetUser;

internal sealed class GetUserHandler : IOperationHandler<GetUserQuery>
{
    private readonly IUserRepository _userRepository;

    public GetUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<OperationResult> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var userId = request.UserId;
        var user = await _userRepository.GetUserByIdAsync(userId, cancellationToken);
        if (user is null)
            return new DoesNotExist($"User with id {userId} not found");

        return new Success<User>(user);
    }
}
