using MediatR;
using Storage.Domain.UserData;

namespace Storage.Application.UserMediator.GetUser;

public record CreateUserCommand(
    string Login,
    string Email,
    string Password) : IRequest<User>;
