using Storage.Application.Repositories;
using Storage.Application.Results;
using Storage.Domain.UserData;

namespace Storage.Application.UserMediator.GetUserList;

internal sealed class GetUserListHandler : IOperationHandler<GetUserListQuery>
{
    private readonly IUserRepository _userRepository;

    public GetUserListHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<OperationResult> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        => _userRepository.GetAllUsersAsync(cancellationToken)
            .ContinueWith(task => new Success<List<User>>(task.Result) as OperationResult, cancellationToken);

}
