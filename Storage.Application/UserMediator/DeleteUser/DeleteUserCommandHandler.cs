using MediatR;
using Storage.Application.Repositories;

namespace Storage.Application.UserMediator.DeleteUser;

internal sealed class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var userId = request.UserId;

        var user = await _userRepository.GetUserByIdAsync(userId, cancellationToken);
        if (user is null)
            throw new ArgumentException($"User with id {userId} not found");

        await _userRepository.DeleteUserAsync(user);
        await _userRepository.SaveUserChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
