using Storage.Application.Repositories;
using Storage.Application.Results;
using Storage.Domain.UserData;

namespace Storage.Application.UserMediator.GetUserListByEmailOrLoginPart;

internal sealed class GetUserListByEmailOrLoginPartQueryHandler : IOperationHandler<GetUserListByEmailOrLoginPartQuery>
{
    private readonly IUserRepository _userRepository;

    public GetUserListByEmailOrLoginPartQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<OperationResult> Handle(GetUserListByEmailOrLoginPartQuery request, CancellationToken cancellationToken)
        => new Success<List<User>>(await _userRepository.GetUsersByEmailOrLoginPartAsync(request.TextPart, cancellationToken));
}
