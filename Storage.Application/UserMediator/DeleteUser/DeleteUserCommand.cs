using MediatR;

namespace Storage.Application.UserMediator.DeleteUser;

public record DeleteUserCommand(Guid UserId) : IRequest<Unit>;
