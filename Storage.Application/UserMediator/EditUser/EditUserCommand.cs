using MediatR;
using Storage.Domain.UserData;

namespace Storage.Application.UserMediator.EditUser;

public record EditUserCommand(Guid UserId,
    string Login,
    string Password) : IRequest<User>;
