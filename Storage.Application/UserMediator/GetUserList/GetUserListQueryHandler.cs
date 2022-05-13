using MediatR;
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

    public async Task<OperationResult> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllUsersAsync(cancellationToken);
        return new Success<List<User>>(users);
    }
}
