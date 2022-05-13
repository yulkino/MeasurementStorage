using Storage.Application.Repositories;
using Storage.Application.Results;

namespace Storage.Application.UserMediator.DeleteUser;

internal sealed class DeleteUserCommandHandler : IOperationHandler<DeleteUserCommand>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<OperationResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var userId = request.UserId;

        var user = await _userRepository.GetUserByIdAsync(userId, cancellationToken);
        if (user is null)
            return new DoesNotExist($"User with id {userId} not found");

        await _userRepository.DeleteUserAsync(user, cancellationToken);
        await _userRepository.SaveChangesAsync(cancellationToken);

        return new WithoutContent();
    }
}
