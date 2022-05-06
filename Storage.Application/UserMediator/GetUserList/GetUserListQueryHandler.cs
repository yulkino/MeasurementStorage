using MediatR;
using Storage.Application.Repositories;
using Storage.Domain.UserData;

namespace Storage.Application.UserMediator.GetUserList;

internal sealed class GetUserListHandler : IRequestHandler<GetUserListQuery, List<User>>
{
    private readonly IUserRepository _userRepository;

    public GetUserListHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<List<User>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        => _userRepository.GetAllUsersAsync(cancellationToken);
}
